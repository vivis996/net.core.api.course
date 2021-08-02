using Microsoft.EntityFrameworkCore;
using net.core.api.Models;

namespace net.core.api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<User> Users { get; set; }
  }
}