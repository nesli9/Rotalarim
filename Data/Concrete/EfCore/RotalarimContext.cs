using Microsoft.EntityFrameworkCore;
using Rotalarim.Entity;

namespace Rotalarim.Data.Concrete.EfCore{
    public class RotalarimContext:DbContext
    {
        public RotalarimContext(DbContextOptions<RotalarimContext> options):base(options){
            
        }
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();


    }
    
}