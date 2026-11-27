using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentPortalWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Agent",
            //    columns: table => new
            //    {
            //        AgentID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AgentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Agent", x => x.AgentID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Item",
            //    columns: table => new
            //    {
            //        ItemID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        StockQuantity = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Item", x => x.ItemID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Order",
            //    columns: table => new
            //    {
            //        OrderID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        AgentID = table.Column<int>(type: "int", nullable: false),
            //        OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Order", x => x.OrderID);
            //        table.ForeignKey(
            //            name: "FK_Order_Agent_AgentID",
            //            column: x => x.AgentID,
            //            principalTable: "Agent",
            //            principalColumn: "AgentID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        UserID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        @lock = table.Column<bool>(name: "lock", type: "bit", nullable: false),
            //        Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
            //        AgentID = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.UserID);
            //        table.ForeignKey(
            //            name: "FK_Users_Agent_AgentID",
            //            column: x => x.AgentID,
            //            principalTable: "Agent",
            //            principalColumn: "AgentID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "OrderDetail",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        OrderID = table.Column<int>(type: "int", nullable: false),
            //        ItemID = table.Column<int>(type: "int", nullable: false),
            //        Quantity = table.Column<int>(type: "int", nullable: false),
            //        UnitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_OrderDetail", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_OrderDetail_Item_ItemID",
            //            column: x => x.ItemID,
            //            principalTable: "Item",
            //            principalColumn: "ItemID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_OrderDetail_Order_OrderID",
            //            column: x => x.OrderID,
            //            principalTable: "Order",
            //            principalColumn: "OrderID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Agent_Phone",
            //    table: "Agent",
            //    column: "Phone",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Order_AgentID",
            //    table: "Order",
            //    column: "AgentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderDetail_ItemID",
            //    table: "OrderDetail",
            //    column: "ItemID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_OrderDetail_OrderID_ItemID",
            //    table: "OrderDetail",
            //    columns: new[] { "OrderID", "ItemID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_AgentID",
            //    table: "Users",
            //    column: "AgentID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_email",
            //    table: "Users",
            //    column: "email",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_UserName",
            //    table: "Users",
            //    column: "UserName",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Agent");
        }
    }
}
