using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KNU.RS.Data.Migrations
{
    public partial class StudyDetailsSchemeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CounterClockwiseDegrees",
                table: "StudyDetails",
                newName: "MinCounterClockwiseDegrees");

            migrationBuilder.RenameColumn(
                name: "ClockwiseDegrees",
                table: "StudyDetails",
                newName: "MinClockwiseDegrees");

            migrationBuilder.AddColumn<decimal>(
                name: "AvgClockwiseDegrees",
                table: "StudyDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AvgCounterClockwiseDegrees",
                table: "StudyDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxClockwiseDegrees",
                table: "StudyDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxCounterClockwiseDegrees",
                table: "StudyDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "0a15e482-6847-4c3c-904b-f0d31e51c078");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "f4d85756-3c83-40fa-9fad-50f4422b7837");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "1580197f-730c-49aa-b746-66093b0bd2f7");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgClockwiseDegrees",
                table: "StudyDetails");

            migrationBuilder.DropColumn(
                name: "AvgCounterClockwiseDegrees",
                table: "StudyDetails");

            migrationBuilder.DropColumn(
                name: "MaxClockwiseDegrees",
                table: "StudyDetails");

            migrationBuilder.DropColumn(
                name: "MaxCounterClockwiseDegrees",
                table: "StudyDetails");

            migrationBuilder.RenameColumn(
                name: "MinCounterClockwiseDegrees",
                table: "StudyDetails",
                newName: "CounterClockwiseDegrees");

            migrationBuilder.RenameColumn(
                name: "MinClockwiseDegrees",
                table: "StudyDetails",
                newName: "ClockwiseDegrees");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "cd94c9c7-7d4d-4f5d-ba43-b48df23bbf90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "b6757695-b8d2-4281-8c28-994c5012c032");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "8fc78a22-38a7-4476-8501-8657f5da1888");
        }
    }
}
