using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.API.BackgroundServices;

// BEGINNER NOTE: this is the second BackgroundService in the app,
// alongside EmailQueueConsumer. That one drains the email queue;
// this one FILLS it - every minute it asks the database "any
// reminders due right now that I haven't emailed yet?", and for each
// one found, publishes an email message and marks it as sent.
//
// It reuses the exact same IEmailQueuePublisher/RabbitMQ pipeline
// that ForgetPassword already uses - a reminder email is really just
// another kind of email, so there's no need for a separate queue.
public class ReminderScannerService : BackgroundService
{
    private static readonly TimeSpan ScanInterval = TimeSpan.FromMinutes(1);

    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IEmailQueuePublisher _emailQueuePublisher;

    // IReminderRL is "Scoped" (one instance per request) because it
    // wraps a DbContext, but a BackgroundService is a long-lived
    // singleton - so instead of injecting IReminderRL directly, we
    // inject a scope FACTORY and create a fresh little scope on every
    // tick of the loop. IEmailQueuePublisher is registered as a
    // Singleton (see Program.cs), so it can be injected here directly.
    public ReminderScannerService(IServiceScopeFactory scopeFactory, IEmailQueuePublisher emailQueuePublisher)
    {
        _scopeFactory = scopeFactory;
        _emailQueuePublisher = emailQueuePublisher;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var reminderRL = scope.ServiceProvider.GetRequiredService<IReminderRL>();

                List<DueReminderModel> dueReminders = reminderRL.GetDueReminders(DateTime.UtcNow);

                foreach (var due in dueReminders)
                {
                    _emailQueuePublisher.Publish(new EmailQueueMessage
                    {
                        ToEmail = due.UserEmail,
                        Subject = $"Reminder: {due.NoteTitle}",
                        Body = $"Just a nudge about your note:\n\nTitle: {due.NoteTitle}\nDescription: {due.NoteDescription}"
                    });

                    // Mark it sent right away so a slow queue/consumer
                    // doesn't cause the SAME reminder to be picked up
                    // again on the next scan a minute later.
                    reminderRL.MarkReminderAsSent(due.ReminderId);
                }
            }

            await Task.Delay(ScanInterval, stoppingToken);
        }
    }
}
