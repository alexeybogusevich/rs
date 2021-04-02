using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KNU.RS.Data.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_DoctorProfiles_DoctorId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_PatientProfiles_PatientId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorProfiles_AspNetUsers_UserId",
                table: "DoctorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorProfiles_Clinics_ClinicId",
                table: "DoctorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorProfiles_Qualifications_QualificationId",
                table: "DoctorProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientProfiles_AspNetUsers_UserId",
                table: "PatientProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientProfiles",
                table: "PatientProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorProfiles",
                table: "DoctorProfiles");

            migrationBuilder.RenameTable(
                name: "PatientProfiles",
                newName: "Patients");

            migrationBuilder.RenameTable(
                name: "DoctorProfiles",
                newName: "Doctors");

            migrationBuilder.RenameIndex(
                name: "IX_PatientProfiles_UserId",
                table: "Patients",
                newName: "IX_Patients_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorProfiles_UserId",
                table: "Doctors",
                newName: "IX_Doctors_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorProfiles_QualificationId",
                table: "Doctors",
                newName: "IX_Doctors_QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorProfiles_ClinicId",
                table: "Doctors",
                newName: "IX_Doctors_ClinicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "01e58d7c-65f9-42b5-a821-c09a871ca201");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "7b14e6df-e4cb-42e1-971b-2e1d3d1c02c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "c9337ebf-ac82-42ac-8f9e-3aa98f4caec1");

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
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Qualifications_QualificationId",
                table: "Doctors",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Doctors_DoctorId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorPatient_Patients_PatientId",
                table: "DoctorPatient");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AspNetUsers_UserId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Clinics_ClinicId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Qualifications_QualificationId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "PatientProfiles");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "DoctorProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_UserId",
                table: "PatientProfiles",
                newName: "IX_PatientProfiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_UserId",
                table: "DoctorProfiles",
                newName: "IX_DoctorProfiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_QualificationId",
                table: "DoctorProfiles",
                newName: "IX_DoctorProfiles_QualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_ClinicId",
                table: "DoctorProfiles",
                newName: "IX_DoctorProfiles_ClinicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientProfiles",
                table: "PatientProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorProfiles",
                table: "DoctorProfiles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "3104fb6d-219e-4bb3-a156-41a1e41281d6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "23175b4b-9b49-4f10-aac8-29678f3c784d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "9218cbcc-e137-4fdc-b6a7-c3d4363870a9");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_DoctorProfiles_DoctorId",
                table: "DoctorPatient",
                column: "DoctorId",
                principalTable: "DoctorProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorPatient_PatientProfiles_PatientId",
                table: "DoctorPatient",
                column: "PatientId",
                principalTable: "PatientProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorProfiles_AspNetUsers_UserId",
                table: "DoctorProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorProfiles_Clinics_ClinicId",
                table: "DoctorProfiles",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorProfiles_Qualifications_QualificationId",
                table: "DoctorProfiles",
                column: "QualificationId",
                principalTable: "Qualifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientProfiles_AspNetUsers_UserId",
                table: "PatientProfiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
