using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.RepositoryLayer.Interfaces;

// "RL" = Repository Layer for reminders. Plain database operations
// only - no rules about who's allowed to do what, that's ReminderBL's job.
public interface IReminderRL
{
    ReminderEntity AddReminder(ReminderEntity reminder);

    // Every "get" here is scoped to a single owner, same ownership
    // pattern used everywhere else in this project.
    List<ReminderEntity> GetAllRemindersForUser(int ownerUserId);
    ReminderEntity? GetReminderByIdAndOwner(int reminderId, int ownerUserId);

    void DeleteReminder(ReminderEntity reminder);

    // Everything the background scanner needs to check every minute:
    // "which reminders are due and haven't been emailed yet", already
    // joined with the note + user info required to compose the email.
    List<DueReminderModel> GetDueReminders(DateTime nowUtc);

    // Called right after an email for a reminder has been handed off
    // to the queue, so the same reminder isn't picked up again on the
    // next scan.
    void MarkReminderAsSent(int reminderId);
}
