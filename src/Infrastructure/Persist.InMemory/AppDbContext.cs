using System.Drawing;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persist.InMemory
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Score> Scores { get; set; }
    }
}