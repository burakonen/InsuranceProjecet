using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class Faqs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainFaqsId",
                table: "Faqs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MainFaqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainFaqs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_MainFaqsId",
                table: "Faqs",
                column: "MainFaqsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_MainFaqs_MainFaqsId",
                table: "Faqs",
                column: "MainFaqsId",
                principalTable: "MainFaqs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_MainFaqs_MainFaqsId",
                table: "Faqs");

            migrationBuilder.DropTable(
                name: "MainFaqs");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_MainFaqsId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "MainFaqsId",
                table: "Faqs");
        }
    }
}
