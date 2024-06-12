using Rotalarim.Entity;

namespace Rotalarim.Data.Abstract{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        void CreateUser(User user);
        
    }
}