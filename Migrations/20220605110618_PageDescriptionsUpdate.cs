using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class PageDescriptionsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PageDescriptions",
                newName: "Header");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PageDescriptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PageDescriptions");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "PageDescriptions",
                newName: "Name");
        }
    }
}
