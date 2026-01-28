using Microsoft.EntityFrameworkCore;
using DistributedPlatform.Sync.Models;

namespace DistributedPlatform.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>().HasKey(t => t.Id);
        modelBuilder.Entity<TaskItem>().Property(t => t.Id).ValueGeneratedOnAdd();
    }
}