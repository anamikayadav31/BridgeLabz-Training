using System.Text;
using System.Text.Json;
using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.Models;
using RabbitMQ.Client;

namespace FundooNotesApp.BusinessLayer.Helpers;

// BEGINNER NOTE: Without a queue, ForgetPassword() would have to call
// an SMTP server directly and WAIT for the email to actually leave
// our server before it can respond to the client - if the mail
// server is slow, the whole HTTP request hangs with it.
//
// Instead, this class does the fast part only: it drops a small JSON
// message ("send this email") onto a RabbitMQ queue and returns
// immediately. A separate background consumer (see
// EmailQueueConsumer in the API project) picks messages off that
// queue whenever it's ready and does the actual, slower SMTP work.
public class EmailQueuePublisher : IEmailQueuePublisher
{
    private readonly string _hostName;
    private readonly string _queueName;

    // Read from appsettings.json ("RabbitMQSettings") and passed in
    // once at startup - same pattern as TokenGenerator's secretKey.
    public EmailQueuePublisher(string hostName, string queueName)
    {
        _hostName = hostName;
        _queueName = queueName;
    }

    public void Publish(EmailQueueMessage message)
    {
        var factory = new ConnectionFactory { HostName = _hostName };

        // "using" here matters: a connection/channel is an unmanaged
        // resource (a real TCP socket) - we open one, use it, and
        // close it again for every publish, instead of leaking sockets.
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        // durable: true => the queue itself survives a RabbitMQ
        // restart, so a message isn't silently lost if the broker
        // happens to restart before the consumer reads it.
        channel.QueueDeclare(
            queue: _queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        string json = JsonSerializer.Serialize(message);
        byte[] body = Encoding.UTF8.GetBytes(json);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true; // survive a broker restart too

        channel.BasicPublish(
            exchange: string.Empty,
            routingKey: _queueName,
            basicProperties: properties,
            body: body);
    }
}
