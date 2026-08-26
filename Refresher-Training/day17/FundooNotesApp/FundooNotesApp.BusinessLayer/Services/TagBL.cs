using FundooNotesApp.BusinessLayer.Interfaces;
using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.ModelLayer.Exceptions;
using FundooNotesApp.ModelLayer.Models;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.BusinessLayer.Services;

// TagBL is the "brain" of the Tags module - same pattern as NoteBL.
// It needs BOTH ITagRL (for tags) and INoteRL (to double-check a note
// really belongs to this user before letting them tag it).
public class TagBL : ITagBL
{
    private readonly ITagRL _tagRL;
    private readonly INoteRL _noteRL;

    public TagBL(ITagRL tagRL, INoteRL noteRL)
    {
        _tagRL = tagRL;
        _noteRL = noteRL;
    }

    public TagModel CreateTag(CreateTagDTO createTagDTO, int ownerUserId)
    {
        var newTag = new TagEntity { Name = createTagDTO.Name, UserId = ownerUserId };
        var savedTag = _tagRL.AddTag(newTag);
        return new TagModel { TagId = savedTag.TagId, Name = savedTag.Name };
    }

    public List<TagModel> GetAllTags(int ownerUserId)
    {
        return _tagRL.GetAllTagsForUser(ownerUserId)
            .Select(t => new TagModel { TagId = t.TagId, Name = t.Name })
            .ToList();
    }

    public TagModel GetTagById(int tagId, int ownerUserId)
    {
        var tag = FindOwnedTagOrThrow(tagId, ownerUserId);
        return new TagModel { TagId = tag.TagId, Name = tag.Name };
    }

    public TagModel EditTag(int tagId, int ownerUserId, EditTagDTO editTagDTO)
    {
        var tag = FindOwnedTagOrThrow(tagId, ownerUserId);
        var renamed = _tagRL.RenameTag(tag, editTagDTO.Name);
        return new TagModel { TagId = renamed.TagId, Name = renamed.Name };
    }

    public void DeleteTag(int tagId, int ownerUserId)
    {
        var tag = FindOwnedTagOrThrow(tagId, ownerUserId);
        _tagRL.DeleteTag(tag);
    }

    public void AttachTagToNote(int noteId, int tagId, int ownerUserId)
    {
        // RULE: both the note AND the tag must belong to the caller -
        // otherwise you could tag someone else's note, or attach a
        // tag you don't own.
        var note = _noteRL.GetNoteByIdAndOwner(noteId, ownerUserId);
        if (note == null)
        {
            throw new NoteNotFoundException("No note found with this id for your account.");
        }
        FindOwnedTagOrThrow(tagId, ownerUserId);

        if (_tagRL.IsTagAlreadyOnNote(noteId, tagId))
        {
            // Attaching the same tag twice isn't an error worth
            // crashing over - we just do nothing and move on.
            return;
        }

        _tagRL.AttachTagToNote(noteId, tagId);
    }

    public void DetachTagFromNote(int noteId, int tagId, int ownerUserId)
    {
        var note = _noteRL.GetNoteByIdAndOwner(noteId, ownerUserId);
        if (note == null)
        {
            throw new NoteNotFoundException("No note found with this id for your account.");
        }
        FindOwnedTagOrThrow(tagId, ownerUserId);

        _tagRL.DetachTagFromNote(noteId, tagId);
    }

    private TagEntity FindOwnedTagOrThrow(int tagId, int ownerUserId)
    {
        var tag = _tagRL.GetTagByIdAndOwner(tagId, ownerUserId);
        if (tag == null)
        {
            throw new TagNotFoundException("No tag found with this id for your account.");
        }
        return tag;
    }
}
