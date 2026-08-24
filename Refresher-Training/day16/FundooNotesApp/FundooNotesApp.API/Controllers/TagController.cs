using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.DTOs.ResponseDTO;
using FundooNotesApp.ModelLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundooNotesApp.API.Controllers;

// Every action here starts with: /api/tags/...
[Authorize]
[Route("api/tags")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagBL _tagBL;

    public TagController(ITagBL tagBL)
    {
        _tagBL = tagBL;
    }

    private int GetLoggedInUserId()
    {
        return int.Parse(User.FindFirst("UserId")!.Value);
    }

    // POST /api/tags/create
    [HttpPost("create")]
    public IActionResult CreateTag([FromBody] CreateTagDTO createTagDTO)
    {
        var tag = _tagBL.CreateTag(createTagDTO, GetLoggedInUserId());
        return StatusCode(201, new ResponseDTO<object>
        {
            Success = true,
            Message = "Tag created successfully.",
            Data = tag
        });
    }

    // GET /api/tags/all
    [HttpGet("all")]
    public IActionResult GetAllTags()
    {
        var tags = _tagBL.GetAllTags(GetLoggedInUserId());
        return Ok(new ResponseDTO<object>
        {
            Success = true,
            Message = $"Found {tags.Count} tag(s).",
            Data = tags
        });
    }

    // DELETE /api/tags/5
    [HttpDelete("{tagId}")]
    public IActionResult DeleteTag(int tagId)
    {
        try
        {
            _tagBL.DeleteTag(tagId, GetLoggedInUserId());
            return Ok(new ResponseDTO<string> { Success = true, Message = "Tag deleted." });
        }
        catch (TagNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // POST /api/tags/5/attach/12   (5 = tagId, 12 = noteId)
    [HttpPost("{tagId}/attach/{noteId}")]
    public IActionResult AttachTagToNote(int tagId, int noteId)
    {
        try
        {
            _tagBL.AttachTagToNote(noteId, tagId, GetLoggedInUserId());
            return Ok(new ResponseDTO<string> { Success = true, Message = "Tag attached to note." });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (TagNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }

    // DELETE /api/tags/5/detach/12
    [HttpDelete("{tagId}/detach/{noteId}")]
    public IActionResult DetachTagFromNote(int tagId, int noteId)
    {
        try
        {
            _tagBL.DetachTagFromNote(noteId, tagId, GetLoggedInUserId());
            return Ok(new ResponseDTO<string> { Success = true, Message = "Tag removed from note." });
        }
        catch (NoteNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
        catch (TagNotFoundException ex)
        {
            return NotFound(new ResponseDTO<string> { Success = false, Message = ex.Message });
        }
    }
}
