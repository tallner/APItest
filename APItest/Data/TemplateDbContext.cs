using APItest.Models.Entities;
using Microsoft.EntityFrameworkCore;
/*
namespace APItest.Data
{
    public class TemplateDbContext: DbContext
    {
        public TemplateDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TemplateEntity> Template { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define entity configurations here
            modelBuilder.Entity<TemplateEntity>()
                .HasKey(n => n.Id); // Set the primary key for the Note entity

            modelBuilder.Entity<TemplateEntity>()
                .Property(n => n.TemplateField2)
                .HasMaxLength(255); // Define constraints on the Title property

            // Define relationships between entities
            /** /
            modelBuilder.Entity<Note>()
            .HasOne(n => n.Author)
            .WithMany(a => a.Notes)
            .HasForeignKey(n => n.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
            /** /
            // Automatically apply pending migrations
            Database.Migrate();
        }
    }
}
*/