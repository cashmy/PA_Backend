using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PA_Backend.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierProviderPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarrierNotes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.CarrierId);
                });

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

            migrationBuilder.CreateTable(
                name: "CPTCodes",
                columns: table => new
                {
                    CPTCodeId = table.Column<int>(type: "int", nullable: false),
                    CPTDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPTCodes", x => x.CPTCodeId);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisCodes",
                columns: table => new
                {
                    DiagCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiagDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisCodes", x => x.DiagCode);
                });

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
                    PatientNotes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PatientInactive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "PlacesOfServices",
                columns: table => new
                {
                    PlaceOfServiceCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaceOfServiceDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesOfServices", x => x.PlaceOfServiceCode);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusTextColor = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "#ffffff"),
                    DisplayOnSummary = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentClass",
                columns: table => new
                {
                    TreatmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TreatmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentClass", x => x.TreatmentCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderRcvEmails = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProviderNPI = table.Column<long>(type: "bigint", nullable: false),
                    ProviderTaxonomy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedStaffUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderNotes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                    table.ForeignKey(
                        name: "FK_Providers_AspNetUsers_AssignedStaffUserId",
                        column: x => x.AssignedStaffUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    PAAuthId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAArchived = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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
                    PANoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                values: new object[,]
                {
                    { "a4916e18-0126-4107-afc0-1e9a05733bfb", "0c9bc621-d3cc-4feb-9a6b-c4af6a48f93e", "User", "USER" },
                    { "7db71b0b-ed91-49c0-9f76-44ccff40be4d", "5d726dd7-cdc7-4982-bbe3-c466a48cf359", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "CPTCodes",
                columns: new[] { "CPTCodeId", "CPTDescription" },
                values: new object[,]
                {
                    { 92507, "Treatment of speech, language, voice, communication, and/or auditory processing disorder." },
                    { 97129, "Therapeutic interventions that focus on cognitive function (e.g., attention, memory, reasoning, executive function, problem-solving and/or pragmatic functioning) and compensatory strategies to manage the performance of an activity (e.g., managing time or schedules, initiating, organizing and sequencing tasks), direct (one-on-one) patient contact; initial 15 minutes" },
                    { 97130, "Each additional 15 minutes. Code 97130 is an add-on code. It will need to be billed in addition to 97129 whenever more than one 15-minute unit is performed. Code 97129 will only ever be billed once per visit. Code 91730 will never be billed alone." },
                    { 97110, "Therapeutic exercises to develop strength, endurance, range of motion and flexibility." }
                });

            migrationBuilder.InsertData(
                table: "Carriers",
                columns: new[] { "CarrierId", "CarrierContactEmail", "CarrierContactName", "CarrierContactPhone", "CarrierName", "CarrierNotes", "CarrierProviderPhone", "CarrierShortName" },
                values: new object[,]
                {
                    { 1, "", "Jane Doe", "(800) 555-1212", "Forward Health", "", "(800) 555-1212", "EDS" },
                    { 2, "", "", "", "United Health Care", "", "", "UHC" }
                });

            migrationBuilder.InsertData(
                table: "Clinics",
                columns: new[] { "ClinicId", "ClinicAddress1", "ClinicAddress2", "ClinicCity", "ClinicIsAGroup", "ClinicNPI", "ClinicName", "ClinicPhone", "ClinicState", "ClinicZip" },
                values: new object[,]
                {
                    { 1, "123 Any Street", "", "Mt Pleasant", true, 1144664293L, "The Playroom, Inc", "(262) 555-1212", "WI", "53406" },
                    { 2, "123 Any Street", "", "Mt Pleasant", false, 1891048211L, "Xaris, Inc", "(262) 555-1212", "WI", "53406" }
                });

            migrationBuilder.InsertData(
                table: "NoteTypes",
                columns: new[] { "NoteTypeId", "NoteTypeName" },
                values: new object[] { 1, "General" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "PatientClass", "PatientDOB", "PatientFirstName", "PatientHaveIEP", "PatientInABA", "PatientLastName", "PatientNotes" },
                values: new object[] { 1, "CO", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1943), "Johnny", true, true, "Quest", "An adventerous boy!" });

            migrationBuilder.InsertData(
                table: "PlacesOfServices",
                columns: new[] { "PlaceOfServiceCode", "PlaceOfServiceDesc" },
                values: new object[,]
                {
                    { "02", "Telehealth" },
                    { "03", "School" },
                    { "11", "Office" },
                    { "12", "Home" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "ProviderId", "AssignedStaffUserId", "ProviderEmail", "ProviderFirstName", "ProviderLastName", "ProviderNPI", "ProviderNotes", "ProviderRcvEmails", "ProviderTaxonomy", "ProviderUserId" },
                values: new object[] { 1, null, "julie@prtherapy123.com", "Julie", "Fitzgerald", 1234567890L, "", true, "", null });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusColor", "StatusName" },
                values: new object[] { 1, "Green", "Approved" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "DisplayOnSummary", "StatusColor", "StatusName" },
                values: new object[,]
                {
                    { 2, true, "Red", "Working" },
                    { 3, true, "DarkRed", "Expired" }
                });

            migrationBuilder.InsertData(
                table: "TreatmentClass",
                columns: new[] { "TreatmentCode", "TreatmentName" },
                values: new object[,]
                {
                    { "OT", "Occupational Therapy" },
                    { "ST", "Speech Therapy" },
                    { "PT", "Physical Therapy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Providers_AssignedStaffUserId",
                table: "Providers",
                column: "AssignedStaffUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PACPTCodes");

            migrationBuilder.DropTable(
                name: "PADiagCodes");

            migrationBuilder.DropTable(
                name: "PANotes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CPTCodes");

            migrationBuilder.DropTable(
                name: "DiagnosisCodes");

            migrationBuilder.DropTable(
                name: "NoteTypes");

            migrationBuilder.DropTable(
                name: "PriorAuths");

            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "PlacesOfServices");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "TreatmentClass");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
