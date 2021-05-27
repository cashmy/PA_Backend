using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class addPatientandProvider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66bf5cef-1330-44e0-be94-eed7b40e41e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af7fb03c-1c52-4b16-b047-1fb6d9149507");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientHaveIEP = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PatientInABA = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PatientClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientNotes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderRcvEmails = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProviderNPI = table.Column<long>(type: "bigint", nullable: false),
                    ProviderTaxonomy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderNotes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                    table.ForeignKey(
                        name: "FK_Providers_AspNetUsers_ProviderUserId",
                        column: x => x.ProviderUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57cdccf5-d472-4734-aab0-d727b3468933", "f9a4f1c6-7b2a-4e52-9130-1b29038eca63", "User", "USER" },
                    { "d1e4f001-6aff-48c1-871b-46c1d126bbff", "4dc67b73-e736-4c27-ab8d-0ae42e32a63b", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientClass", "PatientDOB", "PatientFirstName", "PatientHaveIEP", "PatientInABA", "PatientLastName", "PatientNotes" },
                values: new object[] { 1, "CO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1943), "Johnny", true, true, "Quest", "An adventerous boy!" });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "ProviderId", "ProviderEmail", "ProviderFirstName", "ProviderLastName", "ProviderNPI", "ProviderNotes", "ProviderRcvEmails", "ProviderTaxonomy", "ProviderUserId" },
                values: new object[] { 1, "julie@prtherapy123.com", "Julie", "Fitzgerald", 1234567890L, "", true, "", null });

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ProviderUserId",
                table: "Providers",
                column: "ProviderUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57cdccf5-d472-4734-aab0-d727b3468933");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1e4f001-6aff-48c1-871b-46c1d126bbff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "af7fb03c-1c52-4b16-b047-1fb6d9149507", "3402b933-aefb-4c3e-8a2e-e69d88453d29", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "66bf5cef-1330-44e0-be94-eed7b40e41e2", "fef659ba-8b6c-4eb1-a0d6-69d02f44c05a", "Admin", "ADMIN" });
        }
    }
}
