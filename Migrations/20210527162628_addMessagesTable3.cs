using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addMessagesTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b32c0500-d186-421d-9d90-f7770e802662");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d535eaec-4c04-4f26-b933-18d8ded895c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68cee6fb-b0eb-4d9a-87b3-801fd3844712", "38ea5a85-a91d-4bdb-bcd3-3562f47d616e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71d52835-490f-4d78-8016-0b9b1cbc444e", "84e2bc0e-3691-411e-aada-3447eb1904fd", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68cee6fb-b0eb-4d9a-87b3-801fd3844712");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71d52835-490f-4d78-8016-0b9b1cbc444e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d535eaec-4c04-4f26-b933-18d8ded895c1", "863c2684-dbde-48c6-a147-7e7a1faf2232", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b32c0500-d186-421d-9d90-f7770e802662", "b681ebe6-9fb6-44df-aa28-d85d9d0b20da", "Admin", "ADMIN" });
        }
    }
}
