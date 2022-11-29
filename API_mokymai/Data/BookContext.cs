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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Data-seeding
            modelBuilder.Entity<Book>()
                .HasData(
                BookSet.Books
                );

        }
    }
}
