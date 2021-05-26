using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addStatusMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f593713-6229-431a-ac33-bcf5936a8489");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba2ba229-a833-4ee8-a43c-c18e0e470d75");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOnSummary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d779f9c6-5b99-48a0-9927-891507dca2a2", "76c275ac-78b1-4fac-b119-493e153b3ef5", "User", "USER" },
                    { "0e8bf0ee-c1bd-4d5a-a576-2eeb07d6b119", "5ac9a529-d963-4968-9fe0-a7bfcb3af5d4", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusColor", "StatusName" },
                values: new object[] { 1, "Blue", "Approved" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "DisplayOnSummary", "StatusColor", "StatusName" },
                values: new object[,]
                {
                    { 2, true, "Red", "Working" },
                    { 3, true, "DarkRed", "Expired" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8bf0ee-c1bd-4d5a-a576-2eeb07d6b119");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d779f9c6-5b99-48a0-9927-891507dca2a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba2ba229-a833-4ee8-a43c-c18e0e470d75", "c9ea2bfa-48b6-46bb-adc8-c73e9d3480f6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f593713-6229-431a-ac33-bcf5936a8489", "49a56882-626c-49c6-a7f5-7d089e0f6a37", "Admin", "ADMIN" });
        }
    }
}
