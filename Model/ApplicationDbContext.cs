using Microsoft.EntityFrameworkCore;

namespace Book_list.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
               
        }
        public DbSet<Book> Book{ get; set; }
    }
}
