using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyThirdTest.Migrations
{
    /// <inheritdoc />
    public partial class InitilazeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Project");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Project",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(30)", nullable: false),
                    ProductImg = table.Column<string>(type: "varchar(300)", nullable: true),
                    prix = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product",
                schema: "Project");
        }
    }
}
