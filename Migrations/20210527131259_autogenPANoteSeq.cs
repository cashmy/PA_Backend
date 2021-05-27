using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class autogenPANoteSeq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9074eee1-53b0-4caa-a483-8e67e592aa77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3fd8ef5-b043-4a3d-9f0f-46ba5b5cd084");

            migrationBuilder.AlterColumn<int>(
                name: "PANoteId",
                table: "PANotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3d5cb6b-e30e-41a1-b782-6fabad610e3d", "e3b21899-7705-4ddc-a33a-a00f68bbe428", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efe6b44b-514f-4bfe-b6f4-88e4637612c7", "3a1ab8b3-7aee-4148-b70e-62856cffe75d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3d5cb6b-e30e-41a1-b782-6fabad610e3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efe6b44b-514f-4bfe-b6f4-88e4637612c7");

            migrationBuilder.AlterColumn<int>(
                name: "PANoteId",
                table: "PANotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9074eee1-53b0-4caa-a483-8e67e592aa77", "097f0387-e348-4980-b2e4-b6081257c9b0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3fd8ef5-b043-4a3d-9f0f-46ba5b5cd084", "874a0bcf-ae6e-4050-9b5a-f5d2b7b1cc92", "Admin", "ADMIN" });
        }
    }
}
