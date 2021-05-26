using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addCarrierMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1e65ec9-0a1c-402f-a8a8-049dca32fc0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db374a64-86a2-4a17-8974-ec6da29948ed");

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierProviderPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierNotes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.CarrierId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14981c32-bcf7-451b-b804-a3b433e4ebd1", "40f65a51-0a72-41ff-a62c-8c001d718d81", "User", "USER" },
                    { "cdbf2826-938f-42c3-a45b-9a5853cc4da8", "92d5205d-8c63-44c2-8c9d-83d57ad7275f", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Carriers",
                columns: new[] { "CarrierId", "CarrierContactEmail", "CarrierContactName", "CarrierContactPhone", "CarrierName", "CarrierNotes", "CarrierProviderPhone", "CarrierShortName" },
                values: new object[,]
                {
                    { 1, "", "Jane Doe", "(800) 555-1212", "Forward Health", "", "(800) 555-1212", "EDS" },
                    { 2, "", "", "", "United Health Care", "", "", "UHC" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14981c32-bcf7-451b-b804-a3b433e4ebd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdbf2826-938f-42c3-a45b-9a5853cc4da8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1e65ec9-0a1c-402f-a8a8-049dca32fc0a", "baa7a87c-d3ce-491c-88ca-92ad78c33409", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db374a64-86a2-4a17-8974-ec6da29948ed", "481156d2-f068-4791-8f70-621566b69c89", "Admin", "ADMIN" });
        }
    }
}
