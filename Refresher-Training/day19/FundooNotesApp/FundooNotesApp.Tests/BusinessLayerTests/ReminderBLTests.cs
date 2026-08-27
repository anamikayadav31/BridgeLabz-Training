using Microsoft.VisualStudio.TestTools.UnitTesting;
using FundooNotesApp.BusinessLayer.Services;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.Tests.Fakes;

namespace FundooNotesApp.Tests.BusinessLayerTests;

[TestClass]
public class ReminderBLTests
{
    private static (ReminderBL reminderBL, FakeReminderRepository reminderRepo, FakeNoteRepository noteRepo) CreateSystemUnderTest()
    {
        var reminderRepo = new FakeReminderRepository();
        var noteRepo = new FakeNoteRepository();
        var reminderBL = new ReminderBL(reminderRepo, noteRepo);
        return (reminderBL, reminderRepo, noteRepo);
    }

    [TestMethod]
    public void CreateReminder_ShouldThrow_WhenTheNoteBelongsToSomeoneElse()
    {
        // Same security idea as tags: owning nothing about the
        // reminder itself should let you attach one to someone
        // ELSE'S note just by guessing its id.
        var (reminderBL, _, noteRepo) = CreateSystemUnderTest();
        noteRepo.Notes.Add(new NoteEntity { NoteId = 5, UserId = 99 });

        var dto = new CreateReminderDTO { NoteId = 5, ReminderTime = DateTime.UtcNow.AddHours(1) };

        Assert.ThrowsException<NoteNotFoundException>(() =>
            reminderBL.CreateReminder(dto, ownerUserId: 42));
    }

    [TestMethod]
    public void CreateReminder_ShouldSucceed_WhenTheNoteBelongsToTheCaller()
    {
        var (reminderBL, reminderRepo, noteRepo) = CreateSystemUnderTest();
        noteRepo.Notes.Add(new NoteEntity { NoteId = 5, UserId = 42 });

        var dto = new CreateReminderDTO { NoteId = 5, ReminderTime = DateTime.UtcNow.AddHours(1) };
        var result = reminderBL.CreateReminder(dto, ownerUserId: 42);

        Assert.AreEqual(5, result.NoteId);
        Assert.AreEqual(1, reminderRepo.Reminders.Count);
    }

    [TestMethod]
    public void GetAllReminders_ShouldOnlyReturnTheCallersOwnReminders()
    {
        var (reminderBL, reminderRepo, _) = CreateSystemUnderTest();
        reminderRepo.Reminders.Add(new ReminderEntity { ReminderId = 1, UserId = 42, NoteId = 5, ReminderTime = DateTime.UtcNow });
        reminderRepo.Reminders.Add(new ReminderEntity { ReminderId = 2, UserId = 99, NoteId = 6, ReminderTime = DateTime.UtcNow });

        var result = reminderBL.GetAllReminders(ownerUserId: 42);

        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result[0].ReminderId);
    }

    [TestMethod]
    public void DeleteReminder_ShouldThrow_WhenReminderBelongsToSomeoneElse()
    {
        var (reminderBL, reminderRepo, _) = CreateSystemUnderTest();
        reminderRepo.Reminders.Add(new ReminderEntity { ReminderId = 1, UserId = 99, NoteId = 5, ReminderTime = DateTime.UtcNow });

        Assert.ThrowsException<ReminderNotFoundException>(() =>
            reminderBL.DeleteReminder(reminderId: 1, ownerUserId: 42));
    }
}
