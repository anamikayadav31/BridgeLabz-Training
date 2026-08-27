using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.Tests.Fakes;

// Same idea as FakeUserRepository/FakeNoteRepository - tests shouldn't
// need a real RabbitMQ server running just to check UserBL's logic.
// This fake just remembers what was published so a test can assert
// on it if it wants to.
public class FakeEmailQueuePublisher : IEmailQueuePublisher
{
    public List<EmailQueueMessage> PublishedMessages { get; } = new();

    public void Publish(EmailQueueMessage message)
    {
        PublishedMessages.Add(message);
    }
}
