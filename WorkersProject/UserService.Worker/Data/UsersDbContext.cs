using Microsoft.EntityFrameworkCore;
using UserService.Worker.Models;

namespace UserService.Worker.Data;
public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                Id = Guid.Parse("f9a64b46-2633-4ac1-8a5b-0bb1fd6d64ef"),
                Email = "alice@example.com",
                Name = "Alice",
                Role = "User",
                CreatedAt = DateTime.UtcNow
            },
            new UserEntity
            {
                Id = Guid.Parse("8ad503c2-b7b4-4b32-90a5-ecb0fc734d89"),
                Email = "bob@example.com",
                Name = "Bob",
                Role = "Admin",
                CreatedAt = DateTime.UtcNow
            },
            new UserEntity
            {
                Id = Guid.Parse("a2d1e9e9-89b6-40c8-a66e-5417c92fdd63"),
                Email = "carol@example.com",
                Name = "Carol",
                Role = "User",
                CreatedAt = DateTime.UtcNow
            }
        );
    }
}
