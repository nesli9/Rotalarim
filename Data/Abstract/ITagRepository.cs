using Rotalarim.Entity;

namespace Rotalarim.Data.Abstract{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags { get; }

        void CreateTag(Tag tag);
        
    }
}