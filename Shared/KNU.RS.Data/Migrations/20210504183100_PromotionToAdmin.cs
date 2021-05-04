using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KNU.RS.Data.Migrations
{
    public partial class PromotionToAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PromotedToAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotedToAdmin",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "6a2ac1c7-5acf-4aee-ba0f-2d36d5e25dd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "f01b6d55-a5c5-4e0c-9659-2bafb5e600f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "5619a94d-0bee-468e-8496-da873277c00e");
        }
    }
}
