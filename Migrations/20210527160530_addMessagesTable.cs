using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addMessagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70bd3520-4cd1-4098-baf9-54b21738df87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6d36ae0-a73f-4615-87a2-238bfb55ac92");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4709ff4-17f0-47d7-9016-ed7d120a5a61", "04e922a2-9a34-4750-b015-96dc8cc5dbde", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d07160a6-4ee4-4b94-a8f5-291f09f1dd86", "cdb22390-6713-4f41-85d6-93b54e4d0844", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d07160a6-4ee4-4b94-a8f5-291f09f1dd86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4709ff4-17f0-47d7-9016-ed7d120a5a61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70bd3520-4cd1-4098-baf9-54b21738df87", "62d28d18-47ec-491f-b511-2e0b7c827550", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6d36ae0-a73f-4615-87a2-238bfb55ac92", "83ee318b-850f-4332-b462-0abb752000ee", "Admin", "ADMIN" });
        }
    }
}
