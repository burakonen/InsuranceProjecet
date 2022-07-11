using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class QuickOfferTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuickOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceListId = table.Column<int>(type: "int", nullable: false),
                    İcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuickOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuickOffers_InsuranceLists_InsuranceListId",
                        column: x => x.InsuranceListId,
                        principalTable: "InsuranceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuickOffers_InsuranceListId",
                table: "QuickOffers",
                column: "InsuranceListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuickOffers");
        }
    }
}
