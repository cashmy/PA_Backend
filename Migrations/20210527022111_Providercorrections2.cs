using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class Providercorrections2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "StaffMemberId",
                table: "Providers");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedStaffUserId",
                table: "Providers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9f6492a6-46b9-476a-a99d-0ecc8c0a9977", "551ce40d-9e09-4f71-b0fe-13b0c145b437", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abe53fa2-d462-4a3f-8576-1456d59e91b9", "6a258ced-3d59-4a4f-a976-0d1667f682ad", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_AssignedStaffUserId",
                table: "Providers",
                column: "AssignedStaffUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_AspNetUsers_AssignedStaffUserId",
                table: "Providers",
                column: "AssignedStaffUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Providers_AspNetUsers_AssignedStaffUserId",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Providers_AssignedStaffUserId",
                table: "Providers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f6492a6-46b9-476a-a99d-0ecc8c0a9977");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abe53fa2-d462-4a3f-8576-1456d59e91b9");

            migrationBuilder.AlterColumn<string>(
                name: "AssignedStaffUserId",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
