﻿// <auto-generated />
using CinemaProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaProject.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20230916121227_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CinemaProject.Data.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Detective"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Documentary"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Thriller"
                        });
                });

            modelBuilder.Entity("CinemaProject.Data.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TicketPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 6,
                            ImageUrl = "https://m.media-amazon.com/images/I/71lqDylcvGL._AC_SL1500_.jpg",
                            Name = "Oppenheimer",
                            TicketPrice = 120m
                        },
                        new
                        {
                            Id = 2,
                            GenreId = 2,
                            ImageUrl = "https://deadline.com/wp-content/uploads/2023/04/barbie-BARBIE_VERT_TSR_W_TALENT_2764x4096_DOM_rgb.jpg?w=1280",
                            Name = "PowerBall",
                            TicketPrice = 120m
                        },
                        new
                        {
                            Id = 3,
                            GenreId = 7,
                            ImageUrl = "https://www.joblo.com/wp-content/uploads/2023/04/the-nun-2-review.jpg",
                            Name = "The Nun II",
                            TicketPrice = 120m
                        });
                });

            modelBuilder.Entity("CinemaProject.Data.Entities.Movie", b =>
                {
                    b.HasOne("CinemaProject.Data.Entities.Genre", null)
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaProject.Data.Entities.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}