using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularApp.Migrations
{
    public partial class changeModdels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "paymentOrderDetails");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "paymentOrderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "TotalPrice",
                table: "paymentOrderDetails",
                type: "nvarchar(150)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "BillId",
                table: "paymentOrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "userBills",
                columns: table => new
                {
                    BillNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userBills", x => x.BillNumber);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paymentOrderDetails_BillId",
                table: "paymentOrderDetails",
                column: "BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentOrderDetails_userBills_BillId",
                table: "paymentOrderDetails",
                column: "BillId",
                principalTable: "userBills",
                principalColumn: "BillNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentOrderDetails_userBills_BillId",
                table: "paymentOrderDetails");

            migrationBuilder.DropTable(
                name: "userBills");

            migrationBuilder.DropIndex(
                name: "IX_paymentOrderDetails_BillId",
                table: "paymentOrderDetails");

            migrationBuilder.DropColumn(
                name: "BillId",
                table: "paymentOrderDetails");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "paymentOrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "paymentOrderDetails",
                type: "nvarchar(150)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "paymentOrderDetails",
                type: "nvarchar(150)",
                nullable: true);
        }
    }
}
