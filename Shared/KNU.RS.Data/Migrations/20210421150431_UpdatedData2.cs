using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KNU.RS.Data.Migrations
{
    public partial class UpdatedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "9fc248fb-50a2-42f6-904b-58c11eaa7945");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "f938d00c-dac8-4887-9f51-8307ff2a566d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "8b1fece7-f0b8-41c3-bf37-5e3b9e173098");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("35b9add3-729d-41b9-8a8c-d74681d1d526"),
                column: "Name",
                value: "Лаборант");

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a2e2facf-6554-4bd1-9133-673e0fc45ed0"), "Фізіотерапевт" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("a2e2facf-6554-4bd1-9133-673e0fc45ed0"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "f48404c7-e7bc-4fc9-9be4-3456ef4a3fa5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "6490ec06-a61c-4ba1-bc4e-daa7e6ac4bb5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "603d08c2-ae18-47ce-92fb-4f49b9c481fc");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("35b9add3-729d-41b9-8a8c-d74681d1d526"),
                column: "Name",
                value: "Терапевт");
        }
    }
}
