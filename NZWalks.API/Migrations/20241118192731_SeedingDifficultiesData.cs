using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDifficultiesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6892b538-ee17-4ef4-9351-6ce56facc9c8"), "Medium" },
                    { new Guid("7a72a3b8-cbc8-40b6-8cbc-3742c74b0645"), "Hard" },
                    { new Guid("c8ae3eb1-2b48-404e-8730-4c30ec12f56a"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6892b538-ee17-4ef4-9351-6ce56facc9c8"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7a72a3b8-cbc8-40b6-8cbc-3742c74b0645"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c8ae3eb1-2b48-404e-8730-4c30ec12f56a"));
        }
    }
}
