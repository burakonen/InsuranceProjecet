using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceProject.Migrations
{
    public partial class BlogCategoryAndSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_BlogCategories_BlogCategoryID",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_BlogCategoryID",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "BlogCategoryID",
                table: "SubCategories");

            migrationBuilder.CreateTable(
                name: "BlogCategoryAndSubCategory",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    BlogCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategoryAndSubCategory", x => new { x.BlogCategoryId, x.SubCategoryId });
                    table.ForeignKey(
                        name: "FK_BlogCategoryAndSubCategory_BlogCategories_BlogCategoryId",
                        column: x => x.BlogCategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogCategoryAndSubCategory_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogCategoryAndSubCategory_SubCategoryId",
                table: "BlogCategoryAndSubCategory",
                column: "SubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogCategoryAndSubCategory");

            migrationBuilder.AddColumn<int>(
                name: "BlogCategoryID",
                table: "SubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_BlogCategoryID",
                table: "SubCategories",
                column: "BlogCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_BlogCategories_BlogCategoryID",
                table: "SubCategories",
                column: "BlogCategoryID",
                principalTable: "BlogCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
