using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvukatProjectRepository.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LawyersId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 24, 15, 46, 39, 230, DateTimeKind.Local).AddTicks(8289));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 24, 15, 46, 39, 230, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 24, 15, 46, 39, 230, DateTimeKind.Local).AddTicks(8310));

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LawyersId",
                table: "Questions",
                column: "LawyersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Lawyers_LawyersId",
                table: "Questions",
                column: "LawyersId",
                principalTable: "Lawyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Lawyers_LawyersId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_LawyersId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LawyersId",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 24, 15, 39, 30, 850, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 24, 15, 39, 30, 850, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Lawyers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 12, 24, 15, 39, 30, 850, DateTimeKind.Local).AddTicks(5774));
        }
    }
}
