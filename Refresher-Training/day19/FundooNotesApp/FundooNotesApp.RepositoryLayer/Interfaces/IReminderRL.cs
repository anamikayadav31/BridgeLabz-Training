using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.RepositoryLayer.Interfaces;

// "RL" = Repository Layer for reminders. Plain database operations
// only - no rules about who's allowed to do what, that's ReminderBL's job.
public interface IReminderRL
{
    ReminderEntity AddReminder(ReminderEntity reminder);

    // Every "get" here is scoped to a single owner, same ownership
    // pattern used everywhere else in this project.
    List<ReminderEntity> GetAllRemindersForUser(int ownerUserId);
    ReminderEntity? GetReminderByIdAndOwner(int reminderId, int ownerUserId);

    void DeleteReminder(ReminderEntity reminder);
}
