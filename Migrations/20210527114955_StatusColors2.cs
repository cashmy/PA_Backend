using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class StatusColors2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba9de993-fa3e-49e6-b6ac-78e93ae73836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f52e77-be35-4517-aede-22cf90041b74");

            migrationBuilder.AlterColumn<string>(
                name: "StatusTextColor",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "#ffffff",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9074eee1-53b0-4caa-a483-8e67e592aa77", "097f0387-e348-4980-b2e4-b6081257c9b0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3fd8ef5-b043-4a3d-9f0f-46ba5b5cd084", "874a0bcf-ae6e-4050-9b5a-f5d2b7b1cc92", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9074eee1-53b0-4caa-a483-8e67e592aa77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3fd8ef5-b043-4a3d-9f0f-46ba5b5cd084");

            migrationBuilder.AlterColumn<string>(
                name: "StatusTextColor",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "#ffffff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba9de993-fa3e-49e6-b6ac-78e93ae73836", "2655a82b-bd66-4fbb-8ff5-19f013acc4ee", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5f52e77-be35-4517-aede-22cf90041b74", "c58e34ad-bfb6-4d97-a631-4f947e44508f", "Admin", "ADMIN" });
        }
    }
}
