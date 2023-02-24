using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserControl.Migrations
{
    public partial class adicionandocustoidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9998,
                column: "ConcurrencyStamp",
                value: "be7d9061-7cf4-4c75-8dcf-2b27407edba2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "c17e2e30-2818-46de-aa41-9a9770c25bb3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3409d36-53af-4f37-b2de-006f2b3f37d1", "AQAAAAEAACcQAAAAEGnOo/NbhwHOncy1uBmj/KJDqxUtp0WWQBu+hsuT3vBPg62PvvFUkQh2ywOYa0quGg==", "29d12349-f5ba-4dec-87c4-f721b3287b57" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9998,
                column: "ConcurrencyStamp",
                value: "12f367af-dba5-4179-a8bc-c58b9dd40afe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "6915cb6b-0335-472e-8da7-b27636758135");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9bd583a-aa5a-4525-8ad5-3fba6facffe8", "AQAAAAEAACcQAAAAEC/iNxkz+a9KSqzhIa5dAZg4aB69qtPuQe1Yan4XP5S5iXDK1rxEk4UXGz9yOn8JTg==", "e844f01a-055c-4429-a617-66926abad287" });
        }
    }
}
