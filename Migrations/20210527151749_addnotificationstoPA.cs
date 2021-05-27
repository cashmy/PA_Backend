using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addnotificationstoPA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7db71b0b-ed91-49c0-9f76-44ccff40be4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4916e18-0126-4107-afc0-1e9a05733bfb");

            migrationBuilder.AddColumn<bool>(
                name: "PAExpireWarnNotification",
                table: "PriorAuths",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PAExpiredNotification",
                table: "PriorAuths",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70bd3520-4cd1-4098-baf9-54b21738df87", "62d28d18-47ec-491f-b511-2e0b7c827550", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6d36ae0-a73f-4615-87a2-238bfb55ac92", "83ee318b-850f-4332-b462-0abb752000ee", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70bd3520-4cd1-4098-baf9-54b21738df87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6d36ae0-a73f-4615-87a2-238bfb55ac92");

            migrationBuilder.DropColumn(
                name: "PAExpireWarnNotification",
                table: "PriorAuths");

            migrationBuilder.DropColumn(
                name: "PAExpiredNotification",
                table: "PriorAuths");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4916e18-0126-4107-afc0-1e9a05733bfb", "0c9bc621-d3cc-4feb-9a6b-c4af6a48f93e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7db71b0b-ed91-49c0-9f76-44ccff40be4d", "5d726dd7-cdc7-4982-bbe3-c466a48cf359", "Admin", "ADMIN" });
        }
    }
}
