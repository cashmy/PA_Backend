using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class changedAllNPItoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c38549-e58e-418e-a8cd-a6a4dc2a1439");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b326870-2201-4056-aa42-370654e64c7d");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderNPI",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "ClinicNPI",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c598cfd7-86a2-41a5-bd31-74d237d9026e", "bfdd0c32-2d40-45e9-826d-de8a04142848", "User", "USER" },
                    { "e641d920-4f1d-487c-94f1-6e0fbc565120", "b20cabfb-cd9b-4a1c-9caa-f372f2d1746f", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 1,
                column: "ClinicNPI",
                value: "1144664293");

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 2,
                column: "ClinicNPI",
                value: "1891048211");

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "ProviderNPI",
                value: "1234567890");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c598cfd7-86a2-41a5-bd31-74d237d9026e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e641d920-4f1d-487c-94f1-6e0fbc565120");

            migrationBuilder.AlterColumn<long>(
                name: "ProviderNPI",
                table: "Providers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ClinicNPI",
                table: "Clinics",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b326870-2201-4056-aa42-370654e64c7d", "8652ba7d-ed7a-4b57-9740-d620af5e40b8", "User", "USER" },
                    { "94c38549-e58e-418e-a8cd-a6a4dc2a1439", "7af65c90-c43c-4050-bf11-60f4f784f0d0", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 1,
                column: "ClinicNPI",
                value: 1144664293L);

            migrationBuilder.UpdateData(
                table: "Clinics",
                keyColumn: "ClinicId",
                keyValue: 2,
                column: "ClinicNPI",
                value: 1891048211L);

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "ProviderNPI",
                value: 1234567890L);
        }
    }
}
