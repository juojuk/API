using dotNET_Baigiamasis.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNET_Baigiamasis.Data
{
    public class BookfanasContext: DbContext
    {
        public BookfanasContext(DbContextOptions<BookfanasContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
