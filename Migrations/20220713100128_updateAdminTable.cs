using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class updateAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admin",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "KullanıcıAdı",
                table: "Admin",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Admin",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Admin",
                newName: "KullanıcıAdı");
        }
    }
}
