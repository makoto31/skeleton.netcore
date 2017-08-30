using Skeleton.Models;
using Microsoft.EntityFrameworkCore;

namespace Skeleton.Data
{
    public class SkeletonContext : DbContext
    {
        public SkeletonContext(DbContextOptions<SkeletonContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("person");
        }
    }
}
