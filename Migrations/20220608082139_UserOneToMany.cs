using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class UserOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceListId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_InsuranceListId",
                table: "AspNetUsers",
                column: "InsuranceListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_InsuranceLists_InsuranceListId",
                table: "AspNetUsers",
                column: "InsuranceListId",
                principalTable: "InsuranceLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_InsuranceLists_InsuranceListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_InsuranceListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "InsuranceListId",
                table: "AspNetUsers");
        }
    }
}
