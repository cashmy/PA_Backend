using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class Providercorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_AspNetUsers_ProviderUserId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ProviderUserId",
                table: "Providers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f130ec2-3994-44a5-9f0f-5728853753d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1c87269-baa4-4465-bba9-63670ca547ea");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderUserId",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedStaffUserId",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffMemberId",
                table: "Providers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ca911d0-45ad-4905-b1e9-01a6e55c746e", "63bc53ce-4311-4a46-91c8-7456cb6f8dce", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c692991e-728e-45c8-9b89-e9cd045010c2", "0c2af09f-42d4-4b7e-94e5-6783b4bac273", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_StaffMemberId",
                table: "Providers",
                column: "StaffMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_AspNetUsers_StaffMemberId",
                table: "Providers",
                column: "StaffMemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_AspNetUsers_StaffMemberId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_StaffMemberId",
                table: "Providers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ca911d0-45ad-4905-b1e9-01a6e55c746e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c692991e-728e-45c8-9b89-e9cd045010c2");

            migrationBuilder.DropColumn(
                name: "AssignedStaffUserId",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "StaffMemberId",
                table: "Providers");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderUserId",
                table: "Providers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1c87269-baa4-4465-bba9-63670ca547ea", "a7a461ef-0ea4-422b-8f8c-b3514c17095a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f130ec2-3994-44a5-9f0f-5728853753d2", "b39631d4-bb02-4a8c-8092-ac829cf933c3", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ProviderUserId",
                table: "Providers",
                column: "ProviderUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_AspNetUsers_ProviderUserId",
                table: "Providers",
                column: "ProviderUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
