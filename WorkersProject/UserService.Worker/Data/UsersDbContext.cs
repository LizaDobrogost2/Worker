using Microsoft.EntityFrameworkCore;
using UserService.Worker.Models;

namespace UserService.Worker.Data;
public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
