using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "J.K.", "Rowling" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AvailableLanguage", "BookName", "DateOfPublishment", "Genre", "ImagePath", "Price", "SmallDescription" },
                values: new object[,]
                {
                    { 1, "English", "Harry Potter and the Philosopher's Stone", new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy", "/images/books/HarryPotter1.png", 19.99m, "A young boy discovers he is a wizard and embarks on an adventure at Hogwarts." },
                    { 2, "English", "Harry Potter and the Chamber of Secrets", new DateTime(1998, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy", "/images/books/HarryPotter2.png", 21.99m, "Harry returns to Hogwarts for his second year, where a mysterious chamber has been opened, releasing a deadly monster." },
                    { 3, "English", "Harry Potter and the Prisoner of Azkaban", new DateTime(1999, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fantasy", "/images/books/HarryPotter3.png", 23.99m, "Harry faces new challenges as he learns about Sirius Black, a dangerous prisoner who has escaped from Azkaban." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
