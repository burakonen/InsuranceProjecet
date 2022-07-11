using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class RelatedDocumentsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedDocuments_InsuranceLists_InsuranceListId",
                table: "RelatedDocuments");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceListId",
                table: "RelatedDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedDocuments_InsuranceLists_InsuranceListId",
                table: "RelatedDocuments",
                column: "InsuranceListId",
                principalTable: "InsuranceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedDocuments_InsuranceLists_InsuranceListId",
                table: "RelatedDocuments");

            migrationBuilder.AlterColumn<int>(
                name: "InsuranceListId",
                table: "RelatedDocuments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedDocuments_InsuranceLists_InsuranceListId",
                table: "RelatedDocuments",
                column: "InsuranceListId",
                principalTable: "InsuranceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
