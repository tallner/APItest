using APItest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace APItest.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entity classes (representing tables) go here
        public DbSet<Note> Notes { get; set; }
        public DbSet<TemplateEntity> TemplateEntities { get; set; }
        // Add more DbSet properties for other entity classes as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define entity configurations here
            modelBuilder.Entity<TemplateEntity>()
                .HasKey(n => n.Id); // Set the primary key for the Note entity

            modelBuilder.Entity<TemplateEntity>()
                .Property(n => n.TemplateField2)
                .HasMaxLength(255); // Define constraints on the Title property

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
            /**/
            // Automatically apply pending migrations
            //Database.Migrate();

        }
    }
}
