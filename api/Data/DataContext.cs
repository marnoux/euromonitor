using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> Users { get; set; }
    public DbSet<Book> Book { get; set; }
    public DbSet<Subscription> Subscription { get; set; }
  }
}