using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleStock.Migrations
{
    public partial class makeCategoryIdGeneratedByDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the foreign key constraint from the Products table
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            // Step 2: Drop the primary key constraint from Categories table
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            // Step 3: Drop the existing Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            // Step 4: Add the new Id column with Identity property
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Step 5: Reapply the primary key constraint on the new Id column
            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            // Step 6: Recreate the foreign key constraint in the Products table
            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the foreign key constraint from the Products table
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            // Step 2: Drop the primary key constraint on the Id column
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            // Step 3: Drop the new Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Categories");

            // Step 4: Add the old Id column back without the Identity property
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Step 5: Reapply the primary key constraint on the old Id column
            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            // Step 6: Recreate the foreign key constraint in the Products table
            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
