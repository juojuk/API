using API_mokymai.Models;
using Microsoft.EntityFrameworkCore;

namespace API_mokymai.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {

        }

        // Registruojamos lenteles
        // Prop pavadinimas = Lenteles pavadinimas
        public DbSet<Book> Books { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<AdditionalShippingPrice>  AdditionalShippingPrices { get; set; }
        public DbSet<ShippingOrder> ShippingOrders { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Data - seeding
            modelBuilder.Entity<Book>()
                .HasData(
                BookSet.Books
                );

            modelBuilder.Entity<Role>()
                .HasData(
                RoleSet.Roles
                );

            modelBuilder.Entity<Reservation>()
                .HasOne(b => b.Book)
                .WithMany(d => d.Reservations)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>()
                .HasOne<Person>(b => b.Person)
                .WithMany(d => d.Reservations)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Reservation>()
                .HasOne(b => b.Measure)
                .WithMany(d => d.Reservations)
                .HasForeignKey(d => d.MeasureId)
                .OnDelete(DeleteBehavior.NoAction);

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
