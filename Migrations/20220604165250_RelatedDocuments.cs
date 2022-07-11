using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class RelatedDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatedDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsuranceListId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedDocuments_InsuranceLists_InsuranceListId",
                        column: x => x.InsuranceListId,
                        principalTable: "InsuranceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RelatedDocumentsPDFs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PDF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedDocumentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedDocumentsPDFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RelatedDocumentsPDFs_RelatedDocuments_RelatedDocumentsId",
                        column: x => x.RelatedDocumentsId,
                        principalTable: "RelatedDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedDocuments_InsuranceListId",
                table: "RelatedDocuments",
                column: "InsuranceListId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedDocumentsPDFs_RelatedDocumentsId",
                table: "RelatedDocumentsPDFs",
                column: "RelatedDocumentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedDocumentsPDFs");

            migrationBuilder.DropTable(
                name: "RelatedDocuments");
        }
    }
}
