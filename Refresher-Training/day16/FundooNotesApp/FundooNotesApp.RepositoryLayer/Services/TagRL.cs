using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.RepositoryLayer.Context;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.RepositoryLayer.Services;

// TagRL = the REAL implementation of ITagRL - only class that talks
// to FundooContext for anything tag-related.
public class TagRL : ITagRL
{
    private readonly FundooContext _context;

    public TagRL(FundooContext context)
    {
        _context = context;
    }

    public TagEntity AddTag(TagEntity tag)
    {
        _context.Tags.Add(tag);
        _context.SaveChanges();
        return tag;
    }

    public List<TagEntity> GetAllTagsForUser(int ownerUserId)
    {
        return _context.Tags.Where(t => t.UserId == ownerUserId).ToList();
    }

    public TagEntity? GetTagByIdAndOwner(int tagId, int ownerUserId)
    {
        return _context.Tags.FirstOrDefault(t => t.TagId == tagId && t.UserId == ownerUserId);
    }

    public void DeleteTag(TagEntity tag)
    {
        // Also remove any note-tag links that reference this tag first,
        // otherwise those rows would point at a tag that no longer exists.
        var links = _context.NoteTags.Where(nt => nt.TagId == tag.TagId);
        _context.NoteTags.RemoveRange(links);

        _context.Tags.Remove(tag);
        _context.SaveChanges();
    }

    public bool IsTagAlreadyOnNote(int noteId, int tagId)
    {
        return _context.NoteTags.Any(nt => nt.NoteId == noteId && nt.TagId == tagId);
    }

    public void AttachTagToNote(int noteId, int tagId)
    {
        _context.NoteTags.Add(new NoteTagEntity { NoteId = noteId, TagId = tagId });
        _context.SaveChanges();
    }

    public void DetachTagFromNote(int noteId, int tagId)
    {
        var link = _context.NoteTags.FirstOrDefault(nt => nt.NoteId == noteId && nt.TagId == tagId);
        if (link != null)
        {
            _context.NoteTags.Remove(link);
            _context.SaveChanges();
        }
    }

    public List<TagEntity> GetTagsForNote(int noteId)
    {
        // A small join: find every NoteTag row for this note, then
        // pull back the matching Tag rows.
        var tagIds = _context.NoteTags
            .Where(nt => nt.NoteId == noteId)
            .Select(nt => nt.TagId);

        return _context.Tags.Where(t => tagIds.Contains(t.TagId)).ToList();
    }
}
