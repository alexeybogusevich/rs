using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KNU.RS.Data.Migrations
{
    public partial class AddedPatientDoctorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Patients_PatientId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_RecoveryDailyPlans_DoctorPatient_DoctorPatientId",
                table: "RecoveryDailyPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyHeaders_DoctorPatient_DoctorPatientId",
                table: "StudyHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient");

            migrationBuilder.RenameTable(
                name: "DoctorPatient",
                newName: "DoctorPatients");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatient_PatientId",
                table: "DoctorPatients",
                newName: "IX_DoctorPatients_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatient_DoctorId",
                table: "DoctorPatients",
                newName: "IX_DoctorPatients_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatients",
                table: "DoctorPatients",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "dc385dc4-9b6b-4292-88f7-d20534c71dc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "1c499920-591f-4e1a-b218-06c24f8cbd6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "1d9b5738-fc5b-4fdf-b267-de542bd21d45");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatients_Doctors_DoctorId",
                table: "DoctorPatients",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatients_Patients_PatientId",
                table: "DoctorPatients",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecoveryDailyPlans_DoctorPatients_DoctorPatientId",
                table: "RecoveryDailyPlans",
                column: "DoctorPatientId",
                principalTable: "DoctorPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyHeaders_DoctorPatients_DoctorPatientId",
                table: "StudyHeaders",
                column: "DoctorPatientId",
                principalTable: "DoctorPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatients_Doctors_DoctorId",
                table: "DoctorPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatients_Patients_PatientId",
                table: "DoctorPatients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecoveryDailyPlans_DoctorPatients_DoctorPatientId",
                table: "RecoveryDailyPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyHeaders_DoctorPatients_DoctorPatientId",
                table: "StudyHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorPatients",
                table: "DoctorPatients");

            migrationBuilder.RenameTable(
                name: "DoctorPatients",
                newName: "DoctorPatient");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatients_PatientId",
                table: "DoctorPatient",
                newName: "IX_DoctorPatient_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorPatients_DoctorId",
                table: "DoctorPatient",
                newName: "IX_DoctorPatient_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorPatient",
                table: "DoctorPatient",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "6ccd9114-77de-48f0-81c8-984bea147de9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "4e8082ec-fbce-4eb8-95dd-eade06f47706");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "ff328c51-6ecd-458e-b602-473fa508d5e8");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorId",
                table: "DoctorPatient",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_Patients_PatientId",
                table: "DoctorPatient",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecoveryDailyPlans_DoctorPatient_DoctorPatientId",
                table: "RecoveryDailyPlans",
                column: "DoctorPatientId",
                principalTable: "DoctorPatient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyHeaders_DoctorPatient_DoctorPatientId",
                table: "StudyHeaders",
                column: "DoctorPatientId",
                principalTable: "DoctorPatient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
