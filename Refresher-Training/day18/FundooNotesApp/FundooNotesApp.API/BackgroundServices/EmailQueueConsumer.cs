using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using FundooNotesApp.ModelLayer.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FundooNotesApp.API.BackgroundServices;

// BEGINNER NOTE: a BackgroundService is a class ASP.NET Core starts
// automatically when the API boots up, and keeps running for as long
// as the API is alive - separate from any single HTTP request. This
// is the "other end" of EmailQueuePublisher: it sits and listens on
// the same queue name, and whenever a message shows up, it sends the
// real email over SMTP.
public class EmailQueueConsumer : BackgroundService
{
    private readonly string _hostName;
    private readonly string _queueName;
    private readonly IConfiguration _configuration;

    public EmailQueueConsumer(IConfiguration configuration)
    {
        _configuration = configuration;
        _hostName = configuration["RabbitMQSettings:HostName"]!;
        _queueName = configuration["RabbitMQSettings:QueueName"]!;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory { HostName = _hostName };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: _queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (sender, eventArgs) =>
        {
            try
            {
                byte[] body = eventArgs.Body.ToArray();
                string json = Encoding.UTF8.GetString(body);
                var message = JsonSerializer.Deserialize<EmailQueueMessage>(json);

                if (message != null)
                {
                    SendEmail(message);
                }

                // Tell RabbitMQ this message was handled successfully so
                // it can be removed from the queue.
                channel.BasicAck(eventArgs.DeliveryTag, multiple: false);
            }
            catch (Exception)
            {
                // Something went wrong (bad SMTP creds, network blip,
                // etc). requeue: true puts the message back so it gets
                // tried again instead of silently vanishing.
                channel.BasicNack(eventArgs.DeliveryTag, multiple: false, requeue: true);
            }
        };

        channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

        // Keep this background service alive until the app shuts down.
        // The actual work above happens on the "Received" event, not
        // in a loop here.
        stoppingToken.Register(() =>
        {
            channel.Close();
            connection.Close();
        });

        return Task.CompletedTask;
    }

    private void SendEmail(EmailQueueMessage message)
    {
        string senderEmail = _configuration["SmtpSettings:SenderEmail"]!;
        string senderPassword = _configuration["SmtpSettings:SenderPassword"]!;

        using var smtpClient = new SmtpClient(_configuration["SmtpSettings:Host"])
        {
            Port = int.Parse(_configuration["SmtpSettings:Port"]!),
            Credentials = new NetworkCredential(senderEmail, senderPassword),
            EnableSsl = true
        };

        using var mailMessage = new MailMessage
        {
            From = new MailAddress(senderEmail, "Fundoo Notes App"),
            Subject = message.Subject,
            Body = message.Body
        };
        mailMessage.To.Add(message.ToEmail);

        smtpClient.Send(mailMessage);
    }
}
