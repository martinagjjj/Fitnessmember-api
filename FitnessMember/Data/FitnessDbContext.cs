using FitnessMember.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessMember.Data
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; } = null!; 
        public DbSet<FitnessClass> FitnessClasses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relationship: one FitnessClass → many Members
            modelBuilder.Entity<Member>()
                .HasOne(m => m.FitnessClass)
                .WithMany(fc => fc.Members)
                .HasForeignKey(m => m.FitnessClassId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
