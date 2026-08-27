using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.BusinessLayer.Interfaces;

// Same idea as IUserBL / IUserRL - the rest of the app should only
// ever know "I can publish an email message", never "I talk to
// RabbitMQ on port 5672". That detail is hidden inside the real
// implementation (EmailQueuePublisher).
public interface IEmailQueuePublisher
{
    void Publish(EmailQueueMessage message);
}
