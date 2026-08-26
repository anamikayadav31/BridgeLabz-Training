using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.DTOs.ResponseDTO;
using FundooNotesApp.ModelLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundooNotesApp.API.Controllers;

// Every action here starts with: /api/notes/...
//
// [Authorize] on the WHOLE controller means EVERY endpoint below
// requires a valid "Authorization: Bearer <token>" header - there's
// no such thing as an "anonymous" note, every note belongs to someone.
[Authorize]
[Route("api/notes")]
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
        return int.Parse(User.FindFirst("UserId")!.Value);
    }

    // POST /api/notes/create
    // Creates a new note owned by whoever is currently logged in.
    [HttpPost("create")]
    public IActionResult CreateNote([FromBody] CreateNoteDTO createNoteDTO)
    {
        var createdNote = _noteBL.CreateNote(createNoteDTO, GetLoggedInUserId());

        // 201 Created - a brand-new resource (the note) now exists.
        return StatusCode(201, new ResponseDTO<object>
        {
            Success = true,
            Message = "Note created successfully.",
            Data = createdNote
        });
    }

    // GET /api/notes/all
    // Returns every note (excluding trashed ones) for the logged-in user.
    [HttpGet("all")]
    public IActionResult GetAllNotes()
    {
        var notes = _noteBL.GetAllNotes(GetLoggedInUserId());
        return Ok(new ResponseDTO<object>
        {
            Success = true,
            Message = $"Found {notes.Count} note(s).",
            Data = notes
        });
    }

    // GET /api/notes/5
    // Returns one specific note - only if it belongs to you.
    [HttpGet("{noteId}")]
    public IActionResult GetNoteById(int noteId)
    {
        try
        {
            var note = _noteBL.GetNoteById(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<object> { Success = true, Message = "Note found.", Data = note });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // DELETE /api/notes/5
    // Permanently deletes a note. To keep users from accidentally
    // losing data, this only works on a note that's already in the
    // trash (see the RULE in NoteBL.DeleteNote).
    [HttpDelete("{noteId}")]
    public IActionResult DeleteNote(int noteId)
    {
        try
        {
            _noteBL.DeleteNote(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<string> { Success = true, Message = "Note permanently deleted." });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            // 400 - the note exists and is theirs, but the action isn't allowed right now.
            return BadRequest(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // PATCH /api/notes/5/pin
    // Flips a note's pinned status on/off.
    [HttpPatch("{noteId}/pin")]
    public IActionResult TogglePin(int noteId)
    {
        try
        {
            var note = _noteBL.TogglePin(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<object> { Success = true, Message = "Pin status updated.", Data = note });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // PATCH /api/notes/5/archive
    // Flips a note's archived status on/off.
    [HttpPatch("{noteId}/archive")]
    public IActionResult ToggleArchive(int noteId)
    {
        try
        {
            var note = _noteBL.ToggleArchive(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<object> { Success = true, Message = "Archive status updated.", Data = note });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // PATCH /api/notes/5/trash
    // Moves a note to the trash (soft delete - doesn't remove the row).
    [HttpPatch("{noteId}/trash")]
    public IActionResult MoveToTrash(int noteId)
    {
        try
        {
            var note = _noteBL.MoveToTrash(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<object> { Success = true, Message = "Note moved to trash.", Data = note });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // PATCH /api/notes/5/restore
    // Brings a trashed note back to normal.
    [HttpPatch("{noteId}/restore")]
    public IActionResult RestoreFromTrash(int noteId)
    {
        try
        {
            var note = _noteBL.RestoreFromTrash(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<object> { Success = true, Message = "Note restored.", Data = note });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // GET /api/notes/search?keyword=groceries
    // Finds notes whose TITLE contains the given keyword.
    [HttpGet("search")]
    public IActionResult SearchByTitle([FromQuery] string keyword)
    {
        var notes = _noteBL.SearchByTitle(GetLoggedInUserId(), keyword);
        return Ok(new ResponseDTO<object> { Success = true, Message = $"Found {notes.Count} match(es).", Data = notes });
    }

    // GET /api/notes/filter?keyword=groceries
    // Finds notes whose TITLE **or** DESCRIPTION contains the keyword -
    // a broader search than /search above.
    [HttpGet("filter")]
    public IActionResult FilterByText([FromQuery] string keyword)
    {
        var notes = _noteBL.FilterByText(GetLoggedInUserId(), keyword);
        return Ok(new ResponseDTO<object> { Success = true, Message = $"Found {notes.Count} match(es).", Data = notes });
    }

    // GET /api/notes/summary
    // Quick counts for a dashboard-style view: active / pinned / archived / trashed.
    [HttpGet("summary")]
    public IActionResult GetNotesSummary()
    {
        var summary = _noteBL.GetNotesSummary(GetLoggedInUserId());
        return Ok(new ResponseDTO<object> { Success = true, Message = "Summary calculated.", Data = summary });
    }
}
