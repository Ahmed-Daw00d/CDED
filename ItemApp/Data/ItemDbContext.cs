using ItemApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItemApp.Data
{
    public class ItemDbContext : IdentityDbContext
    {
        public ItemDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemAdd>ItemAdds { get; set; }

        internal object Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
