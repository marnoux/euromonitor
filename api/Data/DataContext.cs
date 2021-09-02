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
    public DbSet<Book> Books { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
  }
}