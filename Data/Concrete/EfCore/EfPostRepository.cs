using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete.EfCore;
using Rotalarim.Entity;

namespace Rotalarim.Data.Concrete
{
    public class EfPostRepository : IPostRepository
    {
        private RotalarimContext _context;
        public EfPostRepository(RotalarimContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;
        public void CreatePost(Post post) //post ekleme kodu
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}