using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrototypProjekta.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sneaker",
                columns: table => new
                {
                    SneakerModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Companyname = table.Column<string>(name: "Company name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelname = table.Column<string>(name: "Model name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sneaker", x => x.SneakerModelId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoryname = table.Column<string>(name: "Category name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SneakerModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Sneaker_SneakerModelId",
                        column: x => x.SneakerModelId,
                        principalTable: "Sneaker",
                        principalColumn: "SneakerModelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_SneakerModelId",
                table: "Category",
                column: "SneakerModelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Sneaker");
        }
    }
}
