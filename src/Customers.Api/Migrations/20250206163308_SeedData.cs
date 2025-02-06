using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Customers.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("394a9151-a3dc-4380-ad11-721b67138c69"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("6f92665b-d7f8-40b5-8a58-aeff9919fd18"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "BirthDate", "Country", "Email", "Gender", "Name", "PostalCode", "Surname" },
                values: new object[,]
                {
                    { new Guid("151808be-4000-424f-8990-474ac9e7c68d"), "53 Pepper Av.", new DateTime(1985, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain", "janecurtis@fakeserver.com", "Female", "Jane", "12345", "Curtis" },
                    { new Guid("587f00f2-66b5-4f46-af06-3a75232ff8c3"), "123 Main", new DateTime(1980, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain", "johndoe@fakeserver.com", "Male", "John", "12345", "Doe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("151808be-4000-424f-8990-474ac9e7c68d"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("587f00f2-66b5-4f46-af06-3a75232ff8c3"));

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "BirthDate", "Country", "Email", "Gender", "Name", "PostalCode", "Surname" },
                values: new object[,]
                {
                    { new Guid("394a9151-a3dc-4380-ad11-721b67138c69"), "53 Pepper Av.", new DateTime(1985, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain", "janecurtis@fakeserver.com", "Female", "Jane", "12345", "Curtis" },
                    { new Guid("6f92665b-d7f8-40b5-8a58-aeff9919fd18"), "123 Main", new DateTime(1980, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain", "johndoe@fakeserver.com", "Male", "John", "12345", "Doe" }
                });
        }
    }
}
