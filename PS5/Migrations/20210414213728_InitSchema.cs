using Microsoft.EntityFrameworkCore.Migrations;

namespace PS5.Migrations
{
    public partial class InitSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maker = table.Column<string>(maxLength: 100, nullable: true),
                    Image = table.Column<string>(maxLength: 100, nullable: true),
                    Url = table.Column<string>(maxLength: 100, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
