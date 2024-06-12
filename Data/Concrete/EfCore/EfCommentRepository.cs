using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete.EfCore;
using Rotalarim.Entity;

namespace Rotalarim.Data.Concrete
{
    public class EfCommentRepository : ICommentRepository
    {
        private RotalarimContext _context;
        public EfCommentRepository(RotalarimContext context)
        {
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments;
        public void CreateComment(Comment comment) //post ekleme kodu
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}