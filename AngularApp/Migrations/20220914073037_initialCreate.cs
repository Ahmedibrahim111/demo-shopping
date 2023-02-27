using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApp.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemMangements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Attachement = table.Column<string>(type: "nvarchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemMangements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProduct = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NumberProducts = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentOrderDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemMangements");

            migrationBuilder.DropTable(
                name: "paymentOrderDetails");
        }
    }
}
