using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.DTOs.ResponseDTO;
using FundooNotesApp.ModelLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundooNotesApp.API.Controllers;

// Every action here starts with: /api/note/...
//
// [Authorize] on the WHOLE controller (instead of on each method) means
// EVERY endpoint below requires a valid "Authorization: Bearer <token>"
// header. This makes sense for notes - there's no such thing as an
// "anonymous" note, every note belongs to someone.
[Authorize]
[Route("api/note")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly INoteBL _noteBL;

    public NoteController(INoteBL noteBL)
    {
        _noteBL = noteBL;
    }

    // Small helper so we don't repeat this claim-reading code in
    // every single action method below.
    private int GetLoggedInUserId()
    {
        // This "UserId" claim was baked into the token back when the
        // user logged in (see TokenGenerator.cs) - we're just reading
        // it back out here, no database call needed.
        string userIdClaim = User.FindFirst("UserId")!.Value;
        return int.Parse(userIdClaim);
    }

    // POST /api/note/create
    // Creates a new note that belongs to whoever is currently logged in.
    [HttpPost("create")]
    public IActionResult CreateNote([FromBody] CreateNoteDTO createNoteDTO)
    {
        int loggedInUserId = GetLoggedInUserId();
        var createdNote = _noteBL.CreateNote(createNoteDTO, loggedInUserId);

        // 201 Created - a brand-new resource (the note) now exists.
        return StatusCode(201, new ResponseDTO<object>
        {
            Success = true,
            Message = "Note created successfully.",
            Data = createdNote
        });
    }

    // DELETE /api/note/delete/5
    // Deletes a note - but ONLY if it belongs to the logged-in user.
    [HttpDelete("delete/{noteId}")]
    public IActionResult DeleteNote(int noteId)
    {
        try
        {
            int loggedInUserId = GetLoggedInUserId();
            string message = _noteBL.DeleteNote(noteId, loggedInUserId);
            return Ok(new ResponseDTO<string> { Success = true, Message = message });
        }
        catch (NoteNotFoundException ex)
        {
            // 404 Not Found - either the id doesn't exist, or it's
            // not this user's note (we don't tell them which).
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }
}
