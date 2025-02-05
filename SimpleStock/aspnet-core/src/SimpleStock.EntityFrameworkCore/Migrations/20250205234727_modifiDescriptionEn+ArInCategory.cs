using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleStock.Migrations
{
    /// <inheritdoc />
    public partial class modifiDescriptionEnArInCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DesciptionEn",
                table: "Categories",
                newName: "DescriptionEn");

            migrationBuilder.RenameColumn(
                name: "DesciptionAr",
                table: "Categories",
                newName: "DescriptionAr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DescriptionEn",
                table: "Categories",
                newName: "DesciptionEn");

            migrationBuilder.RenameColumn(
                name: "DescriptionAr",
                table: "Categories",
                newName: "DesciptionAr");
        }
    }
}
