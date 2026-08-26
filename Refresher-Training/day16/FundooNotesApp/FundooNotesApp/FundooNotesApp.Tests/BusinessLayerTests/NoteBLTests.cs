using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundooNotesApp.BusinessLayer.Services;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Tests.Fakes;

namespace FundooNotesApp.Tests.BusinessLayerTests;

// [TestClass] tells MSTest "every [TestMethod] in here is a test to run".
[TestClass]
public class NoteBLTests
{
    // Small helper so every test starts with a fresh, empty fake
    // repository instead of copy-pasting this setup in every method.
    private static (NoteBL noteBL, FakeNoteRepository repo) CreateSystemUnderTest()
    {
        var repo = new FakeNoteRepository();
        var noteBL = new NoteBL(repo);
        return (noteBL, repo);
    }

    [TestMethod]
    public void CreateNote_ShouldSaveTheTitleAndDescription()
    {
        // Arrange - set up the object we're testing and its inputs.
        var (noteBL, _) = CreateSystemUnderTest();
        var dto = new CreateNoteDTO { Title = "Groceries", Description = "Milk, eggs" };

        // Act - actually call the method we're testing.
        var result = noteBL.CreateNote(dto, ownerUserId: 42);

        // Assert - check the outcome is what we expected.
        Assert.AreEqual("Groceries", result.Title);
        Assert.AreEqual("Milk, eggs", result.Description);
    }

    [TestMethod]
    public void TogglePin_ShouldAlsoUnarchiveTheNote()
    {
        // This test checks the "Pin and Archive are mutually exclusive"
        // rule from NoteBL.TogglePin.
        var (noteBL, repo) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, IsArchived = true });

        var result = noteBL.TogglePin(noteId: 1, ownerUserId: 42);

        Assert.IsTrue(result.IsPinned);
        Assert.IsFalse(result.IsArchived);
    }

    [TestMethod]
    public void TogglePin_ShouldThrow_WhenNoteIsTrashed()
    {
        var (noteBL, repo) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, IsTrashed = true });

        // Assert.ThrowsException checks that calling the code inside
        // the lambda actually throws the exception type we expect.
        Assert.ThrowsException<InvalidOperationException>(() =>
            noteBL.TogglePin(noteId: 1, ownerUserId: 42));
    }

    [TestMethod]
    public void DeleteNote_ShouldThrow_WhenNoteIsNotYetTrashed()
    {
        // This checks the safety-net rule: you can't permanently
        // delete a note unless it's already in the trash.
        var (noteBL, repo) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, IsTrashed = false });

        Assert.ThrowsException<InvalidOperationException>(() =>
            noteBL.DeleteNote(noteId: 1, ownerUserId: 42));
    }

    [TestMethod]
    public void DeleteNote_ShouldSucceed_WhenNoteIsAlreadyTrashed()
    {
        var (noteBL, repo) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, IsTrashed = true });

        noteBL.DeleteNote(noteId: 1, ownerUserId: 42);

        Assert.AreEqual(0, repo.Notes.Count);
    }

    [TestMethod]
    public void TogglePin_ShouldThrow_WhenNoteBelongsToADifferentUser()
    {
        // This checks the ownership rule - user 42 should never be
        // able to touch user 99's note, even by guessing its id.
        var (noteBL, repo) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 99 });

        Assert.ThrowsException<NoteNotFoundException>(() =>
            noteBL.TogglePin(noteId: 1, ownerUserId: 42));
    }

    [TestMethod]
    public void GetAllNotes_ShouldShowPinnedNotesFirst()
    {
        var (noteBL, repo) = CreateSystemUnderTest();
        repo.Notes.Add(new NoteEntity { NoteId = 1, UserId = 42, Title = "Not pinned", IsPinned = false });
        repo.Notes.Add(new NoteEntity { NoteId = 2, UserId = 42, Title = "Pinned", IsPinned = true });

        var result = noteBL.GetAllNotes(ownerUserId: 42);

        Assert.AreEqual("Pinned", result[0].Title);
    }
}
