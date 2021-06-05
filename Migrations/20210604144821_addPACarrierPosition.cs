using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addPACarrierPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53a284b-31ac-44ac-aaca-401d5c3d30c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f77e84-86c2-400e-b8d5-805071cf3725");

            migrationBuilder.AddColumn<string>(
                name: "PACarrierPosition",
                table: "PriorAuths",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "P");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da268ff2-5b29-4766-b7c2-692401f224f5", "74a21f47-3ec6-4f05-94ec-b0bce0753a7a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e37d8074-539b-4403-bd84-1a2c74cf45ec", "acbb04a1-6f75-4463-bbe1-3552ef0ecca7", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da268ff2-5b29-4766-b7c2-692401f224f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e37d8074-539b-4403-bd84-1a2c74cf45ec");

            migrationBuilder.DropColumn(
                name: "PACarrierPosition",
                table: "PriorAuths");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5f77e84-86c2-400e-b8d5-805071cf3725", "8e55e96b-3a1b-4c1f-9e55-cb92bc42c942", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d53a284b-31ac-44ac-aaca-401d5c3d30c1", "ed001ea3-0948-44c7-9ede-65718e94f1e1", "Admin", "ADMIN" });
        }
    }
}
