using APItest.Models.Entities;
using Microsoft.EntityFrameworkCore;
/*
namespace APItest.Data
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define entity configurations here
             modelBuilder.Entity<Note>()
             .HasKey(n => n.Id); // Set the primary key for the Note entity
             
             modelBuilder.Entity<Note>()
             .Property(n => n.Title)
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