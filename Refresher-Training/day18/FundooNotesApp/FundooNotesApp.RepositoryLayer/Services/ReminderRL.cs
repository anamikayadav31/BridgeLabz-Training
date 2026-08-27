using FundooNotesApp.ModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.RepositoryLayer.Context;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.RepositoryLayer.Services;

// ReminderRL = the REAL implementation of IReminderRL - only class
// that talks to FundooContext for anything reminder-related.
public class ReminderRL : IReminderRL
{
    private readonly FundooContext _context;

    public ReminderRL(FundooContext context)
    {
        _context = context;
    }

    public ReminderEntity AddReminder(ReminderEntity reminder)
    {
        _context.Reminders.Add(reminder);
        _context.SaveChanges();
        return reminder;
    }

    public List<ReminderEntity> GetAllRemindersForUser(int ownerUserId)
    {
        // Soonest reminders first - the client would want to see
        // "what's coming up next" at the top of the list.
        return _context.Reminders
            .Where(r => r.UserId == ownerUserId)
            .OrderBy(r => r.ReminderTime)
            .ToList();
    }

    public ReminderEntity? GetReminderByIdAndOwner(int reminderId, int ownerUserId)
    {
        return _context.Reminders
            .FirstOrDefault(r => r.ReminderId == reminderId && r.UserId == ownerUserId);
    }

    public void DeleteReminder(ReminderEntity reminder)
    {
        _context.Reminders.Remove(reminder);
        _context.SaveChanges();
    }

    public List<DueReminderModel> GetDueReminders(DateTime nowUtc)
    {
        // Three-way join, done once here so nothing above this layer
        // needs to know Reminders/Notes/Users are even separate tables.
        return (
            from reminder in _context.Reminders
            where !reminder.IsSent && reminder.ReminderTime <= nowUtc
            join note in _context.Notes on reminder.NoteId equals note.NoteId
            join user in _context.Users on reminder.UserId equals user.UserId
            select new DueReminderModel
            {
                ReminderId = reminder.ReminderId,
                UserEmail = user.Email,
                NoteTitle = note.Title,
                NoteDescription = note.Description
            }
        ).ToList();
    }

    public void MarkReminderAsSent(int reminderId)
    {
        var reminder = _context.Reminders.FirstOrDefault(r => r.ReminderId == reminderId);
        if (reminder != null)
        {
            reminder.IsSent = true;
            _context.SaveChanges();
        }
    }
}
