using dotNET_Baigiamasis.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNET_Baigiamasis.Data
{
    public class BookfanasContext : DbContext

    {
        public BookfanasContext(DbContextOptions<BookfanasContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(
                RoleSet.Roles
                );

            modelBuilder.Entity<Person>()
                .HasIndex(i => i.Email)
                .IsUnique();
            modelBuilder.Entity<Person>()
                .HasOne(r => r.Role)
                .WithMany(p => p.Persons)
                .HasForeignKey(k => k.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}