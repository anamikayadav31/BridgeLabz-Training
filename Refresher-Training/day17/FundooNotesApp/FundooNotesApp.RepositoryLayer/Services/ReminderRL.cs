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
}
