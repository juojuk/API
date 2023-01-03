﻿// <auto-generated />
using System;
using API_mokymai.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APImokymai.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20230103132249_ChangeDistanceKmAdditionalShippingPriceModel")]
    partial class ChangeDistanceKmAdditionalShippingPriceModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("API_mokymai.Models.AdditionalShippingPrice", b =>
                {
                    b.Property<decimal?>("AdditionalPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("DistanceKmId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("DistanceKmId")
                        .IsUnique();

                    b.ToTable("AdditionalShippingPrices");
                });

            modelBuilder.Entity("API_mokymai.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Cover")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PublishYear")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Spainito",
                            Cover = 2,
                            PublishYear = 1900,
                            Quantity = 5,
                            Title = "Orange"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Spainito",
                            Cover = 2,
                            PublishYear = 1910,
                            Quantity = 5,
                            Title = "Apple"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Africana",
                            Cover = 2,
                            PublishYear = 1920,
                            Quantity = 5,
                            Title = "Banana"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Italiano",
                            Cover = 2,
                            PublishYear = 1930,
                            Quantity = 5,
                            Title = "Grapes"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Germaner",
                            Cover = 2,
                            PublishYear = 1940,
                            Quantity = 5,
                            Title = "Sausages"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Belaruska",
                            Cover = 2,
                            PublishYear = 1950,
                            Quantity = 5,
                            Title = "Potatoes"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Belaruska",
                            Cover = 2,
                            PublishYear = 1960,
                            Quantity = 5,
                            Title = "Tomato"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Lithuanis",
                            Cover = 2,
                            PublishYear = 1970,
                            Quantity = 5,
                            Title = "Morkos"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Lithuanis",
                            Cover = 2,
                            PublishYear = 1980,
                            Quantity = 5,
                            Title = "Onions"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Lithuanis",
                            Cover = 2,
                            PublishYear = 1990,
                            Quantity = 5,
                            Title = "Aguonos"
                        });
                });

            modelBuilder.Entity("API_mokymai.Models.Measure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("BaseShippingPrice")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("BorrowingFeeRatio")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxBooksOnHand")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxBorrowingDays")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MaxBorrowingFee")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxOverdueBooks")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MinBorrowingFee")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("API_mokymai.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("API_mokymai.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckOutDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DebtStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MeasureId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ReturnDateTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ShippingStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MeasureId");

                    b.HasIndex("PersonId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("API_mokymai.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Member")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Member = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Member = "editor"
                        },
                        new
                        {
                            Id = 3,
                            Member = "viewer"
                        });
                });

            modelBuilder.Entity("API_mokymai.Models.ShippingOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ConfirmationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("ShippingOrders");
                });

            modelBuilder.Entity("API_mokymai.Models.Person", b =>
                {
                    b.HasOne("API_mokymai.Models.Role", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API_mokymai.Models.Reservation", b =>
                {
                    b.HasOne("API_mokymai.Models.Book", "Book")
                        .WithMany("Reservations")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("API_mokymai.Models.Measure", "Measure")
                        .WithMany("Reservations")
                        .HasForeignKey("MeasureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("API_mokymai.Models.Person", "Person")
                        .WithMany("Reservations")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Measure");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("API_mokymai.Models.ShippingOrder", b =>
                {
                    b.HasOne("API_mokymai.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("API_mokymai.Models.Book", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("API_mokymai.Models.Measure", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("API_mokymai.Models.Person", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("API_mokymai.Models.Role", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
