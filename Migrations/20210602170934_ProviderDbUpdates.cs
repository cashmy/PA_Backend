using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class ProviderDbUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68cee6fb-b0eb-4d9a-87b3-801fd3844712");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71d52835-490f-4d78-8016-0b9b1cbc444e");

            migrationBuilder.AddColumn<bool>(
                name: "ProviderInactive",
                table: "Providers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProviderPhone",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ProviderRcvNotifications",
                table: "Providers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b326870-2201-4056-aa42-370654e64c7d", "8652ba7d-ed7a-4b57-9740-d620af5e40b8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94c38549-e58e-418e-a8cd-a6a4dc2a1439", "7af65c90-c43c-4050-bf11-60f4f784f0d0", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 1,
                columns: new[] { "ProviderPhone", "ProviderRcvNotifications" },
                values: new object[] { "", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94c38549-e58e-418e-a8cd-a6a4dc2a1439");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b326870-2201-4056-aa42-370654e64c7d");

            migrationBuilder.DropColumn(
                name: "ProviderInactive",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ProviderPhone",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ProviderRcvNotifications",
                table: "Providers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68cee6fb-b0eb-4d9a-87b3-801fd3844712", "38ea5a85-a91d-4bdb-bcd3-3562f47d616e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71d52835-490f-4d78-8016-0b9b1cbc444e", "84e2bc0e-3691-411e-aada-3447eb1904fd", "Admin", "ADMIN" });
        }
    }
}
