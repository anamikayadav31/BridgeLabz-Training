using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.BusinessLayer.Services;

// ReminderBL is the "brain" of the Reminder module - same pattern as
// NoteBL and TagBL. It needs BOTH IReminderRL (for reminders) and
// INoteRL (to double-check the note being reminded about really
// belongs to this user).
public class ReminderBL : IReminderBL
{
    private readonly IReminderRL _reminderRL;
    private readonly INoteRL _noteRL;

    public ReminderBL(IReminderRL reminderRL, INoteRL noteRL)
    {
        _reminderRL = reminderRL;
        _noteRL = noteRL;
    }

    public ReminderModel CreateReminder(CreateReminderDTO createReminderDTO, int ownerUserId)
    {
        // RULE: you can only set a reminder on a note that's actually
        // yours - without this check, anyone could attach a reminder
        // to someone else's note just by guessing its id.
        var note = _noteRL.GetNoteByIdAndOwner(createReminderDTO.NoteId, ownerUserId);
        if (note == null)
        {
            throw new NoteNotFoundException("No note found with this id for your account.");
        }

        var newReminder = new ReminderEntity
        {
            NoteId = createReminderDTO.NoteId,
            ReminderTime = createReminderDTO.ReminderTime,
            UserId = ownerUserId
        };

        var savedReminder = _reminderRL.AddReminder(newReminder);
        return ToReminderModel(savedReminder);
    }

    public List<ReminderModel> GetAllReminders(int ownerUserId)
    {
        return _reminderRL.GetAllRemindersForUser(ownerUserId)
            .Select(ToReminderModel)
            .ToList();
    }

    public void DeleteReminder(int reminderId, int ownerUserId)
    {
        var reminder = _reminderRL.GetReminderByIdAndOwner(reminderId, ownerUserId);
        if (reminder == null)
        {
            throw new ReminderNotFoundException("No reminder found with this id for your account.");
        }

        _reminderRL.DeleteReminder(reminder);
    }

    private static ReminderModel ToReminderModel(ReminderEntity reminder)
    {
        return new ReminderModel
        {
            ReminderId = reminder.ReminderId,
            NoteId = reminder.NoteId,
            ReminderTime = reminder.ReminderTime
        };
    }
}
