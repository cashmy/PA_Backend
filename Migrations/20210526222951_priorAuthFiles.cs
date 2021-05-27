using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class priorAuthFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28382bfb-a1fd-485d-a41b-639389342b13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f0e6c83-067e-413a-8327-fb20187e517d");

            migrationBuilder.CreateTable(
                name: "PriorAuths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PAPatientId = table.Column<int>(type: "int", nullable: false),
                    PACarrierId = table.Column<int>(type: "int", nullable: false),
                    PAStatus = table.Column<int>(type: "int", nullable: false),
                    PATreatmentCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PAServiceCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PAProviderId = table.Column<int>(type: "int", nullable: false),
                    PAAssignedStaff = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffMemberId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PAClinicId = table.Column<int>(type: "int", nullable: true),
                    PARequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PALastEvalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PALastPOCDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PAVisitFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PARqstNmbrVisits = table.Column<int>(type: "int", nullable: false),
                    PAStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PAExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PAAuthId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorAuths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriorAuths_AspNetUsers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriorAuths_Carriers_PACarrierId",
                        column: x => x.PACarrierId,
                        principalTable: "Carriers",
                        principalColumn: "CarrierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriorAuths_Clinics_PAClinicId",
                        column: x => x.PAClinicId,
                        principalTable: "Clinics",
                        principalColumn: "ClinicId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriorAuths_Patients_PAPatientId",
                        column: x => x.PAPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriorAuths_PlacesOfServices_PAServiceCode",
                        column: x => x.PAServiceCode,
                        principalTable: "PlacesOfServices",
                        principalColumn: "PlaceOfServiceCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriorAuths_Providers_PAProviderId",
                        column: x => x.PAProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriorAuths_Statuses_PAStatus",
                        column: x => x.PAStatus,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriorAuths_TreatmentClass_PATreatmentCode",
                        column: x => x.PATreatmentCode,
                        principalTable: "TreatmentClass",
                        principalColumn: "TreatmentCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PACPTCodes",
                columns: table => new
                {
                    PARecordId = table.Column<int>(type: "int", nullable: false),
                    PACPTId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PACPTCodes", x => new { x.PARecordId, x.PACPTId });
                    table.ForeignKey(
                        name: "FK_PACPTCodes_CPTCodes_PACPTId",
                        column: x => x.PACPTId,
                        principalTable: "CPTCodes",
                        principalColumn: "CPTCodeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PACPTCodes_PriorAuths_PARecordId",
                        column: x => x.PARecordId,
                        principalTable: "PriorAuths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PADiagCodes",
                columns: table => new
                {
                    PARecordId = table.Column<int>(type: "int", nullable: false),
                    PADiagId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PADiagCodes", x => new { x.PARecordId, x.PADiagId });
                    table.ForeignKey(
                        name: "FK_PADiagCodes_DiagnosisCodes_PADiagId",
                        column: x => x.PADiagId,
                        principalTable: "DiagnosisCodes",
                        principalColumn: "DiagCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PADiagCodes_PriorAuths_PARecordId",
                        column: x => x.PARecordId,
                        principalTable: "PriorAuths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PANotes",
                columns: table => new
                {
                    PARecordId = table.Column<int>(type: "int", nullable: false),
                    PANoteId = table.Column<int>(type: "int", nullable: false),
                    PANoteTypeId = table.Column<int>(type: "int", nullable: false),
                    PANoteText = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PANoteUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PANotes", x => new { x.PARecordId, x.PANoteId });
                    table.ForeignKey(
                        name: "FK_PANotes_AspNetUsers_PANoteUserId",
                        column: x => x.PANoteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PANotes_NoteTypes_PANoteTypeId",
                        column: x => x.PANoteTypeId,
                        principalTable: "NoteTypes",
                        principalColumn: "NoteTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PANotes_PriorAuths_PARecordId",
                        column: x => x.PARecordId,
                        principalTable: "PriorAuths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f1c87269-baa4-4465-bba9-63670ca547ea", "a7a461ef-0ea4-422b-8f8c-b3514c17095a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f130ec2-3994-44a5-9f0f-5728853753d2", "b39631d4-bb02-4a8c-8092-ac829cf933c3", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_PACPTCodes_PACPTId",
                table: "PACPTCodes",
                column: "PACPTId");

            migrationBuilder.CreateIndex(
                name: "IX_PADiagCodes_PADiagId",
                table: "PADiagCodes",
                column: "PADiagId");

            migrationBuilder.CreateIndex(
                name: "IX_PANotes_PANoteTypeId",
                table: "PANotes",
                column: "PANoteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PANotes_PANoteUserId",
                table: "PANotes",
                column: "PANoteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorAuths_PACarrierId",
                table: "PriorAuths",
                column: "PACarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorAuths_PAClinicId",
                table: "PriorAuths",
                column: "PAClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorAuths_PAPatientId",
                table: "PriorAuths",
                column: "PAPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorAuths_PAProviderId",
                table: "PriorAuths",
                column: "PAProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PriorAuths_PAServiceCode",
                table: "PriorAuths",
                column: "PAServiceCode");

            migrationBuilder.CreateIndex(
                name: "IX_PriorAuths_PAStatus",
                table: "PriorAuths",
                column: "PAStatus");

            migrationBuilder.CreateIndex(
                name: "IX_PriorAuths_PATreatmentCode",
                table: "PriorAuths",
                column: "PATreatmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_PriorAuths_StaffMemberId",
                table: "PriorAuths",
                column: "StaffMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PACPTCodes");

            migrationBuilder.DropTable(
                name: "PADiagCodes");

            migrationBuilder.DropTable(
                name: "PANotes");

            migrationBuilder.DropTable(
                name: "PriorAuths");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f130ec2-3994-44a5-9f0f-5728853753d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1c87269-baa4-4465-bba9-63670ca547ea");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28382bfb-a1fd-485d-a41b-639389342b13", "00c6cb22-761c-4db3-8375-1571bbfb6ed5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f0e6c83-067e-413a-8327-fb20187e517d", "c5acfc6b-28a4-4be3-8336-038231a640b3", "Admin", "ADMIN" });
        }
    }
}
