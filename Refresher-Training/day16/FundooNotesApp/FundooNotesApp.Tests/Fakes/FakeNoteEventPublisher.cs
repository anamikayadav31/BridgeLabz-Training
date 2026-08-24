using FundooNotesApp.BusinessLayer.Events;

namespace FundooNotesApp.Tests.Fakes;

// A fake that just REMEMBERS what was published, so a test can check
// "was a NoteCreatedEvent actually raised?" without needing a real
// subscriber (like NLog logging) to be wired up.
public class FakeNoteEventPublisher : INoteEventPublisher
{
    public List<NoteCreatedEvent> CreatedEvents { get; } = new();
    public List<NoteTrashedEvent> TrashedEvents { get; } = new();

    // We don't need real subscribe behaviour for these tests, so these
    // are just empty - only Publish is used/checked.
    public void SubscribeToNoteCreated(Action<NoteCreatedEvent> handler) { }
    public void SubscribeToNoteTrashed(Action<NoteTrashedEvent> handler) { }

    public void PublishNoteCreated(NoteCreatedEvent createdEvent) => CreatedEvents.Add(createdEvent);
    public void PublishNoteTrashed(NoteTrashedEvent trashedEvent) => TrashedEvents.Add(trashedEvent);
}
