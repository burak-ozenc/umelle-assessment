using Microsoft.EntityFrameworkCore;
using Umelle24February2023BurakOzenc.Domain;

namespace Umelle24February2023BurakOzenc.Persistence;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options ) : base(options){}

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}