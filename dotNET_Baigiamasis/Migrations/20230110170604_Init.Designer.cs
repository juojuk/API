﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotNET_Baigiamasis.Data;

#nullable disable

namespace dotNETBaigiamasis.Migrations
{
    [DbContext(typeof(BookfanasContext))]
    [Migration("20230110170604_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("dotNET_Baigiamasis.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = " ",
                            City = " ",
                            Country = " ",
                            Email = "admin@bookfanas.eu",
                            FirstName = " ",
                            LastName = " ",
                            PasswordHash = new byte[] { 246, 9, 181, 154, 36, 121, 138, 51, 122, 36, 221, 81, 140, 159, 106, 166, 166, 73, 199, 66, 221, 44, 132, 251, 219, 38, 29, 20, 65, 55, 206, 146 },
                            PasswordSalt = new byte[] { 42, 51, 41, 10, 138, 254, 166, 39, 23, 75, 123, 211, 230, 45, 44, 228, 82, 11, 174, 13, 190, 95, 16, 61, 210, 111, 34, 202, 200, 184, 111, 10, 169, 93, 199, 148, 35, 89, 176, 241, 100, 22, 212, 205, 95, 113, 44, 209, 30, 239, 207, 102, 12, 251, 245, 5, 171, 156, 231, 146, 135, 224, 170, 142 },
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("dotNET_Baigiamasis.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Member")
                        .IsRequired()
                        .HasMaxLength(10)
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

            modelBuilder.Entity("dotNET_Baigiamasis.Models.Person", b =>
                {
                    b.HasOne("dotNET_Baigiamasis.Models.Role", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("dotNET_Baigiamasis.Models.Role", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}