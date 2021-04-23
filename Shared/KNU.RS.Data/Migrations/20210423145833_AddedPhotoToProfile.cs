using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace KNU.RS.Data.Migrations
{
    public partial class AddedPhotoToProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "49f3e81a-88ef-4385-b5e3-dbd671c5ff67");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "38396bed-20be-49a2-b954-ceaecf8f35bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "2c066f70-02d8-4c45-bf54-0dca53047344");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "AspNetUsers");

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
        }
    }
}
