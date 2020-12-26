using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KNU.RS.DbManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecoveryPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoveryPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clinics_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudySubtypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySubtypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudySubtypes_StudyTypes_StudyTypeId",
                        column: x => x.StudyTypeId,
                        principalTable: "StudyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyHeaders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PatientHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VisitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RecoveryPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyHeaders_RecoveryPlans_RecoveryPlanId",
                        column: x => x.RecoveryPlanId,
                        principalTable: "RecoveryPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyHeaders_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClockwiseDegrees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CounterClockwiseDegrees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StudySubtypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyDetails_StudyHeaders_StudyHeaderId",
                        column: x => x.StudyHeaderId,
                        principalTable: "StudyHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyDetails_StudySubtypes_StudySubtypeId",
                        column: x => x.StudySubtypeId,
                        principalTable: "StudySubtypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clinics_DepartmentId",
                table: "Clinics",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ClinicId",
                table: "Doctors",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_QualificationId",
                table: "Doctors",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyDetails_StudyHeaderId",
                table: "StudyDetails",
                column: "StudyHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyDetails_StudySubtypeId",
                table: "StudyDetails",
                column: "StudySubtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyHeaders_RecoveryPlanId",
                table: "StudyHeaders",
                column: "RecoveryPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyHeaders_VisitId",
                table: "StudyHeaders",
                column: "VisitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudySubtypes_StudyTypeId",
                table: "StudySubtypes",
                column: "StudyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "StudyDetails");

            migrationBuilder.DropTable(
                name: "StudyHeaders");

            migrationBuilder.DropTable(
                name: "StudySubtypes");

            migrationBuilder.DropTable(
                name: "RecoveryPlans");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "StudyTypes");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
