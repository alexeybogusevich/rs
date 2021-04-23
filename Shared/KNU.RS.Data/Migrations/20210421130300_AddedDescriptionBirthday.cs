using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KNU.RS.Data.Migrations
{
    public partial class AddedDescriptionBirthday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "3e2a953f-456f-410d-9989-28842e234f6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "663a30c4-86d7-47f3-a489-7aa9c641da28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "753f8ea0-b32e-42ed-8def-030bcd5f43ec");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "e2cf73ea-4f33-4ebc-8c7e-281231defac3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "eced4282-8f38-4d82-8bfe-34dd5fe30add");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "f1d73fb8-a318-4c09-a9c7-187fc534082e");
        }
    }
}
