using CarApiAiskinimas.Database.InitialData;
using CarApiAiskinimas.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApiAiskinimas.Database
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } //cia yra db lentele
        public DbSet<LocalUser> Users { get; set; }
        public DbSet<CarUser> CarUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(x => x.Id);

            modelBuilder.Entity<Car>().Property(x => x.Mark)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Car>().Property(x => x.Model)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder.Entity<Car>().Property(x => x.Year)
                .IsRequired();

            modelBuilder.Entity<Car>().Property(x => x.PlateNumber)
                .HasMaxLength(20);

            modelBuilder.Entity<Car>().Property(x => x.GearBox)
                .HasConversion(v => v.ToString(), v => (ECarGearBox)Enum.Parse(typeof(ECarGearBox), v))
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Car>().Property(x => x.Fuel)
                .HasConversion(v => v.ToString(), v => (ECarFuel)Enum.Parse(typeof(ECarFuel), v))
                .IsRequired()
                .HasMaxLength(15);

            modelBuilder.Entity<Car>().HasData(CarInitialData.DataSeed);


            modelBuilder.Entity<LocalUser>().HasKey(x => x.Id);

            modelBuilder.Entity<CarUser>().HasKey(x => new { x.CarId, x.LocalUserId });


        }

    }
}