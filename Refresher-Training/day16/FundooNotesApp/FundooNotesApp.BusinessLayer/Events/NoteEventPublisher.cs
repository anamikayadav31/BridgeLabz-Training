namespace FundooNotesApp.BusinessLayer.Events;

// BEGINNER NOTE ON PUB-SUB (Publish - Subscribe):
//
// Without this pattern, NoteCommandBL would need to know EVERY single
// thing that should happen after a note is created - log it, maybe
// email someone, maybe update a search index, etc. That makes
// NoteCommandBL huge and forces it to depend on lots of unrelated
// services.
//
// With Pub-Sub, NoteCommandBL only knows ONE thing: "announce that a
// note was created" (Publish). It has NO idea who - if anyone - is
// listening. Any number of "subscribers" can register themselves
// later (Subscribe), and they'll all be notified automatically. This
// keeps note-creation logic and "what happens afterwards" completely
// decoupled from each other.
public interface INoteEventPublisher
{
    void SubscribeToNoteCreated(Action<NoteCreatedEvent> handler);
    void SubscribeToNoteTrashed(Action<NoteTrashedEvent> handler);

    void PublishNoteCreated(NoteCreatedEvent createdEvent);
    void PublishNoteTrashed(NoteTrashedEvent trashedEvent);
}

// A simple in-memory implementation using plain C# events under the
// hood. Registered as a SINGLETON in Program.cs, so the same instance
// (and the same list of subscribers) is shared for the whole app's
// lifetime - not recreated per request like our other services.
public class NoteEventPublisher : INoteEventPublisher
{
    // The "?" means this can be null until at least one subscriber signs up.
    private event Action<NoteCreatedEvent>? NoteCreated;
    private event Action<NoteTrashedEvent>? NoteTrashed;

    public void SubscribeToNoteCreated(Action<NoteCreatedEvent> handler) => NoteCreated += handler;
    public void SubscribeToNoteTrashed(Action<NoteTrashedEvent> handler) => NoteTrashed += handler;

    public void PublishNoteCreated(NoteCreatedEvent createdEvent) => NoteCreated?.Invoke(createdEvent);
    public void PublishNoteTrashed(NoteTrashedEvent trashedEvent) => NoteTrashed?.Invoke(trashedEvent);
}
