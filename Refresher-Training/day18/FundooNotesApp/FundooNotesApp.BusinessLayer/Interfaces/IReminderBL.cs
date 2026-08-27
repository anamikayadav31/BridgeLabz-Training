using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.BusinessLayer.Interfaces;

// "BL" = Business Layer for reminders. Holds the rule that matters
// most here: you can only set a reminder on a note that's YOURS -
// checked against INoteRL, not just trusted from the request body.
public interface IReminderBL
{
    ReminderModel CreateReminder(CreateReminderDTO createReminderDTO, int ownerUserId);
    List<ReminderModel> GetAllReminders(int ownerUserId);
    void DeleteReminder(int reminderId, int ownerUserId);
}
