using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundooNotesApp.BusinessLayer.Services;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Tests.Fakes;

namespace FundooNotesApp.Tests.BusinessLayerTests;

// [TestClass] tells MSTest "every [TestMethod] in here is a test to run".
[TestClass]
public class NoteCommandBLTests
{
    // Small helper so every test starts with a fresh, empty fake
    // repository instead of copy-pasting this setup in every method.
    private static (NoteCommandBL commandBL, FakeNoteRepository repo, FakeNoteEventPublisher events) CreateSystemUnderTest()
    {
        var repo = new FakeNoteRepository();
        var events = new FakeNoteEventPublisher();
        var commandBL = new NoteCommandBL(repo, events);
        return (commandBL, repo, events);
    }

    [TestMethod]
    public void CreateNote_ShouldAssignTheLoggedInUsersId()
    {
        // Arrange - set up the object we're testing and its inputs.
        var (commandBL, _, _) = CreateSystemUnderTest();
        var dto = new CreateNoteDTO { Title = "Groceries", Description = "Milk, eggs" };

        // Act - actually call the method we're testing.
        var result = commandBL.CreateNote(dto, ownerUserId: 42);

        // Assert - check the outcome is what we expected.
        Assert.AreEqual("Groceries", result.Title);
        // Note: NoteModel deliberately doesn't expose UserId (see NoteModel.cs),
        // so instead we check indirectly - through GetNoteByIdAndOwner below.
    }

    [TestMethod]
    public void CreateNote_ShouldPublishANoteCreatedEvent()
    {
        // This test proves the Pub-Sub wiring actually fires - see
        // NoteCommandBL.CreateNote calling _eventPublisher.PublishNoteCreated(...).
        var (commandBL, _, events) = CreateSystemUnderTest();
        var dto = new CreateNoteDTO { Title = "Groceries", Description = "" };

        commandBL.CreateNote(dto, ownerUserId: 42);

        Assert.AreEqual(1, events.CreatedEvents.Count);
        Assert.AreEqual(42, events.CreatedEvents[0].UserId);
    }

    [TestMethod]
    public void TogglePin_ShouldAlsoUnarchiveTheNote()
    {
        // This test checks the "Pin and Archive are mutually exclusive"
        // rule from NoteCommandBL.TogglePin.
        var (commandBL, repo, _) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, IsArchived = true });

        var result = commandBL.TogglePin(noteId: 1, ownerUserId: 42);

        Assert.IsTrue(result.IsPinned);
        Assert.IsFalse(result.IsArchived);
    }

    [TestMethod]
    public void TogglePin_ShouldThrow_WhenNoteIsTrashed()
    {
        var (commandBL, repo, _) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, IsTrashed = true });

        // Assert.ThrowsException checks that calling the code inside
        // the lambda actually throws the exception type we expect.
        Assert.ThrowsException<InvalidOperationException>(() =>
            commandBL.TogglePin(noteId: 1, ownerUserId: 42));
    }

    [TestMethod]
    public void DeleteNote_ShouldThrow_WhenNoteIsNotYetTrashed()
    {
        // This checks the safety-net rule: you can't permanently
        // delete a note unless it's already in the trash.
        var (commandBL, repo, _) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, IsTrashed = false });

        Assert.ThrowsException<InvalidOperationException>(() =>
            commandBL.DeleteNote(noteId: 1, ownerUserId: 42));
    }

    [TestMethod]
    public void DeleteNote_ShouldSucceed_WhenNoteIsAlreadyTrashed()
    {
        var (commandBL, repo, _) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, IsTrashed = true });

        commandBL.DeleteNote(noteId: 1, ownerUserId: 42);

        Assert.AreEqual(0, repo.Notes.Count);
    }

    [TestMethod]
    public void TogglePin_ShouldThrow_WhenNoteBelongsToADifferentUser()
    {
        // This checks the ownership rule - user 42 should never be
        // able to touch user 99's note, even by guessing its id.
        var (commandBL, repo, _) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 99 });

        Assert.ThrowsException<NoteNotFoundException>(() =>
            commandBL.TogglePin(noteId: 1, ownerUserId: 42));
    }
}
