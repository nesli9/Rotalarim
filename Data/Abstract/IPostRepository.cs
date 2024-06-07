using Rotalarim.Entity;

namespace Rotalarim.Data.Abstract{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }

        void CreatePost(Post post);
        
    }
}