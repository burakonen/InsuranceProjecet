using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class FaqsUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_InsuranceLists_InsuranceListId",
                table: "Faqs");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceListId",
                table: "Faqs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_InsuranceLists_InsuranceListId",
                table: "Faqs",
                column: "InsuranceListId",
                principalTable: "InsuranceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_InsuranceLists_InsuranceListId",
                table: "Faqs");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceListId",
                table: "Faqs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_InsuranceLists_InsuranceListId",
                table: "Faqs",
                column: "InsuranceListId",
                principalTable: "InsuranceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
