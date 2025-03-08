﻿// <auto-generated />
using System;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookStore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250308143625_AddAuthors")]
    partial class AddAuthors
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("integer");

                    b.Property<int>("BooksId")
                        .HasColumnType("integer");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");

                    b.HasData(
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 1
                        },
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 2
                        },
                        new
                        {
                            AuthorsId = 1,
                            BooksId = 3
                        });
                });

            modelBuilder.Entity("BookStore.Components.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "J.K.",
                            LastName = "Rowling"
                        });
                });

            modelBuilder.Entity("BookStore.Components.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AvailableLanguage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfPublishment")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("SmallDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableLanguage = "English",
                            BookName = "Harry Potter and the Philosopher's Stone",
                            DateOfPublishment = new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Utc),
                            Genre = "Fantasy",
                            ImagePath = "/images/books/HarryPotter1.png",
                            Price = 19.99m,
                            SmallDescription = "A young boy discovers he is a wizard and embarks on an adventure at Hogwarts."
                        },
                        new
                        {
                            Id = 2,
                            AvailableLanguage = "English",
                            BookName = "Harry Potter and the Chamber of Secrets",
                            DateOfPublishment = new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            Genre = "Fantasy",
                            ImagePath = "/images/books/HarryPotter2.png",
                            Price = 21.99m,
                            SmallDescription = "Harry returns to Hogwarts for his second year, where a mysterious chamber has been opened, releasing a deadly monster."
                        },
                        new
                        {
                            Id = 3,
                            AvailableLanguage = "English",
                            BookName = "Harry Potter and the Prisoner of Azkaban",
                            DateOfPublishment = new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc),
                            Genre = "Fantasy",
                            ImagePath = "/images/books/HarryPotter3.png",
                            Price = 23.99m,
                            SmallDescription = "Harry faces new challenges as he learns about Sirius Black, a dangerous prisoner who has escaped from Azkaban."
                        });
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("BookStore.Components.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Components.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
