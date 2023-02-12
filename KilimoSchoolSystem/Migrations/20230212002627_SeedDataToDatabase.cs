using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KilimoSchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stream",
                columns: new[] { "StreamId", "StreamName" },
                values: new object[,]
                {
                    { 1, "Form 1A" },
                    { 2, "Form 1B" },
                    { 3, "Form 1C" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "AdmissionNumber", "DOB", "Name", "StreamId" },
                values: new object[,]
                {
                    { 1, "k123/2020", new DateTime(2005, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jake Osin", 2 },
                    { 2, "k124/2020", new DateTime(2005, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marie Danov", 3 },
                    { 3, "k125/2020", new DateTime(2005, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Morris", 1 },
                    { 4, "k126/2020", new DateTime(2005, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blessing Nuvida", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stream",
                keyColumn: "StreamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stream",
                keyColumn: "StreamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stream",
                keyColumn: "StreamId",
                keyValue: 3);
        }
    }
}
