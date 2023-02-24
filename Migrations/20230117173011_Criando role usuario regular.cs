using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserControl.Migrations
{
    public partial class Criandoroleusuarioregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "6915cb6b-0335-472e-8da7-b27636758135");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 9998, "12f367af-dba5-4179-a8bc-c58b9dd40afe", "Regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9bd583a-aa5a-4525-8ad5-3fba6facffe8", "AQAAAAEAACcQAAAAEC/iNxkz+a9KSqzhIa5dAZg4aB69qtPuQe1Yan4XP5S5iXDK1rxEk4UXGz9yOn8JTg==", "e844f01a-055c-4429-a617-66926abad287" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999,
                column: "ConcurrencyStamp",
                value: "1fdbed5d-fb13-4a4e-bb1f-2bd2404b5aed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39aa4ada-efda-4c64-952c-1c1b10d7ce10", "AQAAAAEAACcQAAAAEEKiIEcVQi3M70FD1yrSslzOm53SMon3fC90UlQ/Mc5+Mj7gwqL6ni3L7VXoV1f20w==", "a920fbae-34a2-46dd-a4c5-1ec77464ed67" });
        }
    }
}
