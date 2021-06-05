using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addCarrierFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c598cfd7-86a2-41a5-bd31-74d237d9026e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e641d920-4f1d-487c-94f1-6e0fbc565120");

            migrationBuilder.AddColumn<string>(
                name: "CarrierClass",
                table: "Carriers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CarrierPARequired",
                table: "Carriers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f5f77e84-86c2-400e-b8d5-805071cf3725", "8e55e96b-3a1b-4c1f-9e55-cb92bc42c942", "User", "USER" },
                    { "d53a284b-31ac-44ac-aaca-401d5c3d30c1", "ed001ea3-0948-44c7-9ede-65718e94f1e1", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Carriers",
                keyColumn: "CarrierId",
                keyValue: 1,
                columns: new[] { "CarrierClass", "CarrierPARequired" },
                values: new object[] { "MD", true });

            migrationBuilder.UpdateData(
                table: "Carriers",
                keyColumn: "CarrierId",
                keyValue: 2,
                column: "CarrierClass",
                value: "CO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d53a284b-31ac-44ac-aaca-401d5c3d30c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5f77e84-86c2-400e-b8d5-805071cf3725");

            migrationBuilder.DropColumn(
                name: "CarrierClass",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "CarrierPARequired",
                table: "Carriers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c598cfd7-86a2-41a5-bd31-74d237d9026e", "bfdd0c32-2d40-45e9-826d-de8a04142848", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e641d920-4f1d-487c-94f1-6e0fbc565120", "b20cabfb-cd9b-4a1c-9caa-f372f2d1746f", "Admin", "ADMIN" });
        }
    }
}
