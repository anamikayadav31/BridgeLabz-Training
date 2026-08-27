using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundooNotesApp.BusinessLayer.Services;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Tests.Fakes;

namespace FundooNotesApp.Tests.BusinessLayerTests;

[TestClass]
public class TagBLTests
{
    private static (TagBL tagBL, FakeTagRepository tagRepo, FakeNoteRepository noteRepo) CreateSystemUnderTest()
    {
        var tagRepo = new FakeTagRepository();
        var noteRepo = new FakeNoteRepository();
        var tagBL = new TagBL(tagRepo, noteRepo);
        return (tagBL, tagRepo, noteRepo);
    }

    [TestMethod]
    public void CreateTag_ShouldStoreItUnderTheOwnersId()
    {
        var (tagBL, tagRepo, _) = CreateSystemUnderTest();

        tagBL.CreateTag(new CreateTagDTO { Name = "Work" }, ownerUserId: 42);

        Assert.AreEqual(1, tagRepo.Tags.Count);
        Assert.AreEqual(42, tagRepo.Tags[0].UserId);
    }

    [TestMethod]
    public void AttachTagToNote_ShouldThrow_WhenTheNoteBelongsToSomeoneElse()
    {
        // This is the important security check for tags: even if you
        // own the tag, you still can't attach it to someone ELSE'S note.
        var (tagBL, tagRepo, noteRepo) = CreateSystemUnderTest();
        tagRepo.Tags.Add(new TagEntity { TagId = 1, UserId = 42, Name = "Work" });
        noteRepo.Notes.Add(new NoteEntity { NoteId = 5, UserId = 99 }); // belongs to a different user

        Assert.ThrowsException<NoteNotFoundException>(() =>
            tagBL.AttachTagToNote(noteId: 5, tagId: 1, ownerUserId: 42));
    }

    [TestMethod]
    public void AttachTagToNote_ShouldSucceed_WhenBothNoteAndTagBelongToTheCaller()
    {
        var (tagBL, tagRepo, noteRepo) = CreateSystemUnderTest();
        tagRepo.Tags.Add(new TagEntity { TagId = 1, UserId = 42, Name = "Work" });
        noteRepo.Notes.Add(new NoteEntity { NoteId = 5, UserId = 42 });

        tagBL.AttachTagToNote(noteId: 5, tagId: 1, ownerUserId: 42);

        Assert.IsTrue(tagRepo.IsTagAlreadyOnNote(5, 1));
    }

    [TestMethod]
    public void EditTag_ShouldUpdateTheName()
    {
        var (tagBL, tagRepo, _) = CreateSystemUnderTest();
        tagRepo.Tags.Add(new TagEntity { TagId = 1, UserId = 42, Name = "Work" });

        var result = tagBL.EditTag(tagId: 1, ownerUserId: 42, new EditTagDTO { Name = "Urgent" });

        Assert.AreEqual("Urgent", result.Name);
    }

    [TestMethod]
    public void EditTag_ShouldThrow_WhenTagBelongsToSomeoneElse()
    {
        var (tagBL, tagRepo, _) = CreateSystemUnderTest();
        tagRepo.Tags.Add(new TagEntity { TagId = 1, UserId = 99, Name = "Work" });

        Assert.ThrowsException<TagNotFoundException>(() =>
            tagBL.EditTag(tagId: 1, ownerUserId: 42, new EditTagDTO { Name = "Hacked" }));
    }
}
