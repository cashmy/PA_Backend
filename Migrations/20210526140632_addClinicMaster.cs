using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addClinicMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1799bb34-b494-497f-9926-663c21ab47cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "999266ce-a61b-4650-b0ed-ccaa178faeca");

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicAddress1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicAddress2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicZip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClinicNPI = table.Column<long>(type: "bigint", nullable: false),
                    ClinicIsAGroup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.ClinicId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1e65ec9-0a1c-402f-a8a8-049dca32fc0a", "baa7a87c-d3ce-491c-88ca-92ad78c33409", "User", "USER" },
                    { "db374a64-86a2-4a17-8974-ec6da29948ed", "481156d2-f068-4791-8f70-621566b69c89", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicId", "ClinicAddress1", "ClinicAddress2", "ClinicCity", "ClinicIsAGroup", "ClinicNPI", "ClinicName", "ClinicPhone", "ClinicState", "ClinicZip" },
                values: new object[,]
                {
                    { 1, "123 Any Street", "", "Mt Pleasant", true, 1144664293L, "The Playroom, Inc", "(262) 555-1212", "WI", "53406" },
                    { 2, "123 Any Street", "", "Mt Pleasant", false, 1891048211L, "Xaris, Inc", "(262) 555-1212", "WI", "53406" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1e65ec9-0a1c-402f-a8a8-049dca32fc0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db374a64-86a2-4a17-8974-ec6da29948ed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1799bb34-b494-497f-9926-663c21ab47cf", "ca67c264-752f-408f-b579-3139f9928923", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "999266ce-a61b-4650-b0ed-ccaa178faeca", "24297beb-04b2-4f6f-a56e-b495638db32d", "Admin", "ADMIN" });
        }
    }
}
