using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete.EfCore;
using Rotalarim.Entity;

namespace Rotalarim.Data.Concrete
{
    public class EfTagRepository : ITagRepository
    {
        private RotalarimContext _context;
        public EfTagRepository(RotalarimContext context)
        {
            _context = context;
        }
        public IQueryable<Tag> Tags => _context.Tags;
        public void CreateTag(Tag tag) //tag ekleme kodu
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
    }
}