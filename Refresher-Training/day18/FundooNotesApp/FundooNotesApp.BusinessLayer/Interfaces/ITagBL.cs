using FundooNotesApp.ModelLayer.DTOs.RequestDTO;
using FundooNotesApp.ModelLayer.Models;

namespace FundooNotesApp.BusinessLayer.Interfaces;

// "BL" = Business Layer for tags. Holds the rules: a user can only
// manage their OWN tags, and can only attach a tag to a note that's
// also THEIRS - both checked using the UserId from the JWT token.
public interface ITagBL
{
    TagModel CreateTag(CreateTagDTO createTagDTO, int ownerUserId);
    List<TagModel> GetAllTags(int ownerUserId);
    TagModel GetTagById(int tagId, int ownerUserId);
    TagModel EditTag(int tagId, int ownerUserId, EditTagDTO editTagDTO);
    void DeleteTag(int tagId, int ownerUserId);

    void AttachTagToNote(int noteId, int tagId, int ownerUserId);
    void DetachTagFromNote(int noteId, int tagId, int ownerUserId);
}
