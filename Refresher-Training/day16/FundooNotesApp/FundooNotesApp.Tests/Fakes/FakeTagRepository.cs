using FundooNotesApp.ModelLayer.Entities;
using FundooNotesApp.RepositoryLayer.Interfaces;

namespace FundooNotesApp.Tests.Fakes;

public class FakeTagRepository : ITagRL
{
    public List<TagEntity> Tags { get; } = new();
    public List<NoteTagEntity> Links { get; } = new();
    private int _nextTagId = 1;

    public TagEntity AddTag(TagEntity tag)
    {
        tag.TagId = _nextTagId++;
        Tags.Add(tag);
        return tag;
    }

    public List<TagEntity> GetAllTagsForUser(int ownerUserId) =>
        Tags.Where(t => t.UserId == ownerUserId).ToList();

    public TagEntity? GetTagByIdAndOwner(int tagId, int ownerUserId) =>
        Tags.FirstOrDefault(t => t.TagId == tagId && t.UserId == ownerUserId);

    public void DeleteTag(TagEntity tag)
    {
        Links.RemoveAll(l => l.TagId == tag.TagId);
        Tags.Remove(tag);
    }

    public bool IsTagAlreadyOnNote(int noteId, int tagId) =>
        Links.Any(l => l.NoteId == noteId && l.TagId == tagId);

    public void AttachTagToNote(int noteId, int tagId) =>
        Links.Add(new NoteTagEntity { NoteId = noteId, TagId = tagId });

    public void DetachTagFromNote(int noteId, int tagId) =>
        Links.RemoveAll(l => l.NoteId == noteId && l.TagId == tagId);

    public List<TagEntity> GetTagsForNote(int noteId)
    {
        var tagIds = Links.Where(l => l.NoteId == noteId).Select(l => l.TagId);
        return Tags.Where(t => tagIds.Contains(t.TagId)).ToList();
    }
}
