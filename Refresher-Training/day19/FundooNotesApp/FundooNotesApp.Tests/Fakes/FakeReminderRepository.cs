using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.Tests.Fakes;

public class FakeReminderRepository : IReminderRL
{
    public List<ReminderEntity> Reminders { get; } = new();
    private int _nextId = 1;

    public ReminderEntity AddReminder(ReminderEntity reminder)
    {
        reminder.ReminderId = _nextId++;
        Reminders.Add(reminder);
        return reminder;
    }

    public List<ReminderEntity> GetAllRemindersForUser(int ownerUserId) =>
        Reminders.Where(r => r.UserId == ownerUserId).OrderBy(r => r.ReminderTime).ToList();

    public ReminderEntity? GetReminderByIdAndOwner(int reminderId, int ownerUserId) =>
        Reminders.FirstOrDefault(r => r.ReminderId == reminderId && r.UserId == ownerUserId);

    public void DeleteReminder(ReminderEntity reminder) => Reminders.Remove(reminder);
}
