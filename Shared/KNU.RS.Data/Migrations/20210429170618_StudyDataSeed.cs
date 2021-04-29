using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KNU.RS.Data.Migrations
{
    public partial class StudyDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "StudyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42"), "Обстеження шийного відділу" });

            migrationBuilder.InsertData(
                table: "StudySubtypes",
                columns: new[] { "Id", "Name", "StudyTypeId" },
                values: new object[] { new Guid("89e5b4be-aef1-4107-a7ed-32e05efb864b"), "Поворот по осі крену", new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42") });

            migrationBuilder.InsertData(
                table: "StudySubtypes",
                columns: new[] { "Id", "Name", "StudyTypeId" },
                values: new object[] { new Guid("b492fb11-5e11-4a4a-9ab9-575c9eaa1be6"), "Поворот по осі рискання", new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42") });

            migrationBuilder.InsertData(
                table: "StudySubtypes",
                columns: new[] { "Id", "Name", "StudyTypeId" },
                values: new object[] { new Guid("d785a91d-18ba-40f4-ad5a-c353ecf81bed"), "Поворот по осі тангажу", new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudySubtypes",
                keyColumn: "Id",
                keyValue: new Guid("89e5b4be-aef1-4107-a7ed-32e05efb864b"));

            migrationBuilder.DeleteData(
                table: "StudySubtypes",
                keyColumn: "Id",
                keyValue: new Guid("b492fb11-5e11-4a4a-9ab9-575c9eaa1be6"));

            migrationBuilder.DeleteData(
                table: "StudySubtypes",
                keyColumn: "Id",
                keyValue: new Guid("d785a91d-18ba-40f4-ad5a-c353ecf81bed"));

            migrationBuilder.DeleteData(
                table: "StudyTypes",
                keyColumn: "Id",
                keyValue: new Guid("568342a7-cc8b-476d-a76b-f6519a9e2b42"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ec23f46-4f31-457f-b9b7-16f4fb090ee3"),
                column: "ConcurrencyStamp",
                value: "d132a71b-d3cf-4e31-a428-fbbe957e1fa0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7322ebe8-cfc4-4bd8-8cf9-67a9ceeae0a3"),
                column: "ConcurrencyStamp",
                value: "6d383ac4-bc51-4282-a243-ead2441e8bc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c63e87f9-dee0-4ec5-911c-a8d2c591dc17"),
                column: "ConcurrencyStamp",
                value: "2e63918c-3451-4056-8102-62de24c68cec");
        }
    }
}
