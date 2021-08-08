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
    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Skill>().HasData(
        new Skill { Id = 1, Name = "Force", Damage = 100, },
        new Skill { Id = 2, Name = "Dark Rays", Damage = 110, },
        new Skill { Id = 3, Name = "Push", Damage = 80, }
      );

      modelBuilder.Entity<User>()
          .Property(user => user.Role).HasDefaultValue("Player");
    }
  }
}