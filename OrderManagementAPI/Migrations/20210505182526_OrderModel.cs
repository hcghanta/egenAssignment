using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagementAPI.Migrations
{
    public partial class OrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order_Shipping_Charges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Shipping_Address = table.Column<int>(type: "int", nullable: false),
                    Order_DeliveryType_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Order_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");
        }
    }
}
