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
//
// BEGINNER NOTE ON CQRS: notice this controller takes in TWO business
// interfaces instead of one - INoteCommandBL for anything that changes
// data, and INoteQueryBL for anything that only reads it. The
// Controller doesn't do the split itself, it just calls whichever one
// matches the HTTP verb: GET -> query side, POST/PATCH/DELETE -> command side.
[Authorize]
[Route("api/notes")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly INoteCommandBL _noteCommandBL;
    private readonly INoteQueryBL _noteQueryBL;

    public NoteController(INoteCommandBL noteCommandBL, INoteQueryBL noteQueryBL)
    {
        _noteCommandBL = noteCommandBL;
        _noteQueryBL = noteQueryBL;
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

    // ---------------------- COMMANDS (change data) ----------------------

    // POST /api/notes/create
    [HttpPost("create")]
    public IActionResult CreateNote([FromBody] CreateNoteDTO createNoteDTO)
    {
        var createdNote = _noteCommandBL.CreateNote(createNoteDTO, GetLoggedInUserId());

        // 201 Created - a brand-new resource (the note) now exists.
        return StatusCode(201, new ResponseDTO<object>
        {
            Success = true,
            Message = "Note created successfully.",
            Data = createdNote
        });
    }

    // DELETE /api/notes/5
    // Permanently deletes a note. Only works on a note that's already
    // in the trash (see the RULE in NoteCommandBL.DeleteNote).
    [HttpDelete("{noteId}")]
    public IActionResult DeleteNote(int noteId)
    {
        try
        {
            _noteCommandBL.DeleteNote(noteId, GetLoggedInUserId());
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
    [HttpPatch("{noteId}/pin")]
    public IActionResult TogglePin(int noteId)
    {
        try
        {
            var note = _noteCommandBL.TogglePin(noteId, GetLoggedInUserId());
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
    [HttpPatch("{noteId}/archive")]
    public IActionResult ToggleArchive(int noteId)
    {
        try
        {
            var note = _noteCommandBL.ToggleArchive(noteId, GetLoggedInUserId());
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
    [HttpPatch("{noteId}/trash")]
    public IActionResult MoveToTrash(int noteId)
    {
        try
        {
            var note = _noteCommandBL.MoveToTrash(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<object> { Success = true, Message = "Note moved to trash.", Data = note });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // PATCH /api/notes/5/restore
    [HttpPatch("{noteId}/restore")]
    public IActionResult RestoreFromTrash(int noteId)
    {
        try
        {
            var note = _noteCommandBL.RestoreFromTrash(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<object> { Success = true, Message = "Note restored.", Data = note });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // ---------------------- QUERIES (read-only) ----------------------

    // GET /api/notes/all
    // Pinned notes come first, then newest-first within each group.
    [HttpGet("all")]
    public IActionResult GetAllNotes()
    {
        var notes = _noteQueryBL.GetAllNotes(GetLoggedInUserId());
        return Ok(new ResponseDTO<object>
        {
            Success = true,
            Message = $"Found {notes.Count} note(s).",
            Data = notes
        });
    }

    // GET /api/notes/5
    [HttpGet("{noteId}")]
    public IActionResult GetNoteById(int noteId)
    {
        try
        {
            var note = _noteQueryBL.GetNoteById(noteId, GetLoggedInUserId());
            return Ok(new ResponseDTO<object> { Success = true, Message = "Note found.", Data = note });
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
        var notes = _noteQueryBL.SearchByTitle(GetLoggedInUserId(), keyword);
        return Ok(new ResponseDTO<object> { Success = true, Message = $"Found {notes.Count} match(es).", Data = notes });
    }

    // GET /api/notes/filter?keyword=groceries
    // Finds notes whose TITLE **or** DESCRIPTION contains the keyword -
    // a broader search than /search above.
    [HttpGet("filter")]
    public IActionResult FilterByText([FromQuery] string keyword)
    {
        var notes = _noteQueryBL.FilterByText(GetLoggedInUserId(), keyword);
        return Ok(new ResponseDTO<object> { Success = true, Message = $"Found {notes.Count} match(es).", Data = notes });
    }

    // GET /api/notes/summary
    // Quick counts for a dashboard-style view (uses GroupBy under the
    // hood - see NoteQueryBL.GetNotesSummary for the LINQ).
    [HttpGet("summary")]
    public IActionResult GetNotesSummary()
    {
        var summary = _noteQueryBL.GetNotesSummary(GetLoggedInUserId());
        return Ok(new ResponseDTO<object> { Success = true, Message = "Summary calculated.", Data = summary });
    }
}
