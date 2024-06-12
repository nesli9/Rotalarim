using Rotalarim.Entity;

namespace Rotalarim.Data.Abstract{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }

        void CreateComment(Comment comment);
        
    }
}