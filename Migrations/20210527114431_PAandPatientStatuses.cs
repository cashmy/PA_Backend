using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class PAandPatientStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f6492a6-46b9-476a-a99d-0ecc8c0a9977");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abe53fa2-d462-4a3f-8576-1456d59e91b9");

            migrationBuilder.AddColumn<bool>(
                name: "PAArchived",
                table: "PriorAuths",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PatientInactive",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b1b4a73-8488-4cc8-b487-74e98477ca73", "44eab4a0-3feb-4292-b9be-cd747d058de2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "005702aa-b586-4bc6-b9f4-c13a742fed75", "6aad42be-5d7c-41bc-82d4-cb5733e68499", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "005702aa-b586-4bc6-b9f4-c13a742fed75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b1b4a73-8488-4cc8-b487-74e98477ca73");

            migrationBuilder.DropColumn(
                name: "PAArchived",
                table: "PriorAuths");

            migrationBuilder.DropColumn(
                name: "PatientInactive",
                table: "Patients");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f6492a6-46b9-476a-a99d-0ecc8c0a9977", "551ce40d-9e09-4f71-b0fe-13b0c145b437", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abe53fa2-d462-4a3f-8576-1456d59e91b9", "6a258ced-3d59-4a4f-a976-0d1667f682ad", "Admin", "ADMIN" });
        }
    }
}
