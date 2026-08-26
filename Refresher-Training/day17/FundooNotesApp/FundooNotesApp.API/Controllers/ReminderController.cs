using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.DTOs.ResponseDTO;
using FundooNotesApp.ModelLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundooNotesApp.API.Controllers;

// Every action here starts with: /api/reminders/...
[Authorize]
[Route("api/reminders")]
[ApiController]
public class ReminderController : ControllerBase
{
    private readonly IReminderBL _reminderBL;

    public ReminderController(IReminderBL reminderBL)
    {
        _reminderBL = reminderBL;
    }

    private int GetLoggedInUserId()
    {
        return int.Parse(User.FindFirst("UserId")!.Value);
    }

    // POST /api/reminders/create
    [HttpPost("create")]
    public IActionResult CreateReminder([FromBody] CreateReminderDTO createReminderDTO)
    {
        try
        {
            var reminder = _reminderBL.CreateReminder(createReminderDTO, GetLoggedInUserId());
            return StatusCode(201, new ResponseDTO<object>
            {
                Success = true,
                Message = "Reminder set successfully.",
                Data = reminder
            });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // GET /api/reminders/all
    [HttpGet("all")]
    public IActionResult GetAllReminders()
    {
        var reminders = _reminderBL.GetAllReminders(GetLoggedInUserId());
        return Ok(new ResponseDTO<object>
        {
            Success = true,
            Message = $"Found {reminders.Count} reminder(s).",
            Data = reminders
        });
    }

    // DELETE /api/reminders/5
    [HttpDelete("{reminderId}")]
    public IActionResult DeleteReminder(int reminderId)
    {
        try
        {
            _reminderBL.DeleteReminder(reminderId, GetLoggedInUserId());
            return Ok(new ResponseDTO<string> { Success = true, Message = "Reminder removed." });
        }
        catch (ReminderNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }
}
