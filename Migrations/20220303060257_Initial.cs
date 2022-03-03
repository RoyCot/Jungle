﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Jungle.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
                //name: "Books",
                //columns: table => new
                //{
                    //BookId = table.Column<int>(nullable: false)
                        //.Annotation("Sqlite:Autoincrement", true),
                    //Title = table.Column<string>(nullable: true),
                    //Author = table.Column<string>(nullable: true),
                    //Publisher = table.Column<string>(nullable: true),
                    //Isbn = table.Column<string>(nullable: true),
                    //Classification = table.Column<string>(nullable: true),
                    //Category = table.Column<string>(nullable: true),
                    //PageCount = table.Column<int>(nullable: false),
                    //Price = table.Column<double>(nullable: false)
                //},
                //constraints: table =>
                //{
                    //table.PrimaryKey("PK_Books", x => x.BookId);
                //});

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartLineItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    CheckoutPurchaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartLineItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartLineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartLineItem_Purchases_CheckoutPurchaseId",
                        column: x => x.CheckoutPurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartLineItem_BookId",
                table: "ShoppingCartLineItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartLineItem_CheckoutPurchaseId",
                table: "ShoppingCartLineItem",
                column: "CheckoutPurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartLineItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
