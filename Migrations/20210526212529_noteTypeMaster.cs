using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class noteTypeMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57cdccf5-d472-4734-aab0-d727b3468933");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1e4f001-6aff-48c1-871b-46c1d126bbff");

            migrationBuilder.CreateTable(
                name: "NoteTypes",
                columns: table => new
                {
                    NoteTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteTypes", x => x.NoteTypeId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28382bfb-a1fd-485d-a41b-639389342b13", "00c6cb22-761c-4db3-8375-1571bbfb6ed5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f0e6c83-067e-413a-8327-fb20187e517d", "c5acfc6b-28a4-4be3-8336-038231a640b3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "NoteTypes",
                columns: new[] { "NoteTypeId", "NoteTypeName" },
                values: new object[] { 1, "General" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28382bfb-a1fd-485d-a41b-639389342b13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f0e6c83-067e-413a-8327-fb20187e517d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57cdccf5-d472-4734-aab0-d727b3468933", "f9a4f1c6-7b2a-4e52-9130-1b29038eca63", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1e4f001-6aff-48c1-871b-46c1d126bbff", "4dc67b73-e736-4c27-ab8d-0ae42e32a63b", "Admin", "ADMIN" });
        }
    }
}
