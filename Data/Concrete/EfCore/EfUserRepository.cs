using Rotalarim.Data.Abstract;
using Rotalarim.Data.Concrete.EfCore;
using Rotalarim.Entity;

namespace Rotalarim.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private RotalarimContext _context;
        public EfUserRepository(RotalarimContext context)
        {
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}