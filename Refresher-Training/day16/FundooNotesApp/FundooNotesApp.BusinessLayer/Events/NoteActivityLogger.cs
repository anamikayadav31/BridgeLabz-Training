using Microsoft.Extensions.Logging;

namespace FundooNotesApp.BusinessLayer.Events;

// This is a SUBSCRIBER - it doesn't create or trash notes itself, it
// just reacts whenever someone else announces that one of those
// things happened. NoteCommandBL has never heard of this class, and
// never needs to - that's the whole point of pub-sub.
//
// You could add a second, completely different subscriber later
// (e.g. one that sends an email) without touching NoteCommandBL or
// this class at all.
public class NoteActivityLogger
{
    private readonly ILogger<NoteActivityLogger> _logger;

    public NoteActivityLogger(ILogger<NoteActivityLogger> logger)
    {
        _logger = logger;
    }

    // Call this once at startup (see Program.cs) to start listening.
    public void SubscribeTo(INoteEventPublisher publisher)
    {
        publisher.SubscribeToNoteCreated(HandleNoteCreated);
        publisher.SubscribeToNoteTrashed(HandleNoteTrashed);
    }

    private void HandleNoteCreated(NoteCreatedEvent createdEvent)
    {
        _logger.LogInformation(
            "[Activity] User {UserId} created note {NoteId} ('{Title}') at {Time}",
            createdEvent.UserId, createdEvent.NoteId, createdEvent.Title, createdEvent.OccurredAt);
    }

    private void HandleNoteTrashed(NoteTrashedEvent trashedEvent)
    {
        _logger.LogInformation(
            "[Activity] User {UserId} moved note {NoteId} to trash at {Time}",
            trashedEvent.UserId, trashedEvent.NoteId, trashedEvent.OccurredAt);
    }
}
