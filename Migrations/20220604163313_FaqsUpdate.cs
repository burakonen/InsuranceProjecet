using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class FaqsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuanceListId",
                table: "MainFaqs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsuranceListId",
                table: "MainFaqs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainFaqs_InsuranceListId",
                table: "MainFaqs",
                column: "InsuranceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainFaqs_InsuranceLists_InsuranceListId",
                table: "MainFaqs",
                column: "InsuranceListId",
                principalTable: "InsuranceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainFaqs_InsuranceLists_InsuranceListId",
                table: "MainFaqs");

            migrationBuilder.DropIndex(
                name: "IX_MainFaqs_InsuranceListId",
                table: "MainFaqs");

            migrationBuilder.DropColumn(
                name: "InsuanceListId",
                table: "MainFaqs");

            migrationBuilder.DropColumn(
                name: "InsuranceListId",
                table: "MainFaqs");
        }
    }
}
