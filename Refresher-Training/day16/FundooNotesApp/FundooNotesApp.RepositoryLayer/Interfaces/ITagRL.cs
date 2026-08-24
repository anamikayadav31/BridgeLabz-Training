using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.RepositoryLayer.Interfaces;

// "RL" = Repository Layer for tags. Plain database operations only -
// no rules about who's allowed to do what, that's TagBL's job.
public interface ITagRL
{
    TagEntity AddTag(TagEntity tag);
    List<TagEntity> GetAllTagsForUser(int ownerUserId);
    TagEntity? GetTagByIdAndOwner(int tagId, int ownerUserId);
    void DeleteTag(TagEntity tag);

    // Managing the many-to-many link between a note and a tag.
    bool IsTagAlreadyOnNote(int noteId, int tagId);
    void AttachTagToNote(int noteId, int tagId);
    void DetachTagFromNote(int noteId, int tagId);
    List<TagEntity> GetTagsForNote(int noteId);
}
