using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KNU.RS.Data.Migrations
{
    public partial class NormalizedRoleNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "StudyHeaders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "9a8c0491-ecc2-458d-bb8c-31f5831b1085", "DOCTOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "585aa649-cb3b-46cf-aa90-79b7294e9554", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "5c0f0473-1c6f-4956-95e0-53f93d3e6092", "PATIENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "StudyHeaders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "01e58d7c-65f9-42b5-a821-c09a871ca201", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "7b14e6df-e4cb-42e1-971b-2e1d3d1c02c3", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "c9337ebf-ac82-42ac-8f9e-3aa98f4caec1", null });
        }
    }
}
