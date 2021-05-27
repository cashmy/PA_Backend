using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class StatusColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "005702aa-b586-4bc6-b9f4-c13a742fed75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b1b4a73-8488-4cc8-b487-74e98477ca73");

            migrationBuilder.AddColumn<string>(
                name: "StatusTextColor",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba9de993-fa3e-49e6-b6ac-78e93ae73836", "2655a82b-bd66-4fbb-8ff5-19f013acc4ee", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5f52e77-be35-4517-aede-22cf90041b74", "c58e34ad-bfb6-4d97-a631-4f947e44508f", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9de993-fa3e-49e6-b6ac-78e93ae73836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f52e77-be35-4517-aede-22cf90041b74");

            migrationBuilder.DropColumn(
                name: "StatusTextColor",
                table: "Statuses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b1b4a73-8488-4cc8-b487-74e98477ca73", "44eab4a0-3feb-4292-b9be-cd747d058de2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "005702aa-b586-4bc6-b9f4-c13a742fed75", "6aad42be-5d7c-41bc-82d4-cb5733e68499", "Admin", "ADMIN" });
        }
    }
}
