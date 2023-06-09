using System;
using System.Collections.Generic;
using ConnectionPoint.Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionPoint.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inventory");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameAr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionAr = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalSchema: "inventory",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalLimit = table.Column<int>(type: "integer", nullable: false),
                    PerUserLimit = table.Column<int>(type: "integer", nullable: false),
                    StartsOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndsOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AvailableOn = table.Column<IList<Day>>(type: "jsonb", nullable: false),
                    DealId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    NameAr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionAr = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    NetPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxesIds = table.Column<string>(type: "jsonb", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountType = table.Column<int>(type: "integer", nullable: false),
                    AvailableOnShop = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deals_Deals_DealId",
                        column: x => x.DealId,
                        principalSchema: "inventory",
                        principalTable: "Deals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    ProductType = table.Column<int>(type: "integer", nullable: false),
                    ParentProduct = table.Column<Guid>(type: "uuid", nullable: true),
                    DealId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    NameAr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionAr = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    NetPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxesIds = table.Column<string>(type: "jsonb", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountType = table.Column<int>(type: "integer", nullable: false),
                    AvailableOnShop = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Deals_DealId",
                        column: x => x.DealId,
                        principalSchema: "inventory",
                        principalTable: "Deals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "inventory",
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceType = table.Column<int>(type: "integer", nullable: false),
                    EmployeesIds = table.Column<string>(type: "text", nullable: false),
                    DealId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    NameAr = table.Column<string>(type: "text", nullable: false),
                    NameEn = table.Column<string>(type: "text", nullable: false),
                    DescriptionAr = table.Column<string>(type: "text", nullable: false),
                    DescriptionEn = table.Column<string>(type: "text", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    NetPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxesIds = table.Column<string>(type: "jsonb", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountType = table.Column<int>(type: "integer", nullable: false),
                    AvailableOnShop = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Deals_DealId",
                        column: x => x.DealId,
                        principalSchema: "inventory",
                        principalTable: "Deals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                schema: "inventory",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "inventory",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalSchema: "inventory",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductUnitQuantity",
                schema: "inventory",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUnitQuantity", x => new { x.ProductId, x.UnitId });
                    table.ForeignKey(
                        name: "FK_ProductUnitQuantity_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "inventory",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUnitQuantity_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "inventory",
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryService",
                schema: "inventory",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServicesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryService", x => new { x.CategoriesId, x.ServicesId });
                    table.ForeignKey(
                        name: "FK_CategoryService_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalSchema: "inventory",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryService_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalSchema: "inventory",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProduct",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "inventory",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProduct_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "inventory",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                schema: "inventory",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                schema: "inventory",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryService_ServicesId",
                schema: "inventory",
                table: "CategoryService",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_AvailableOn",
                schema: "inventory",
                table: "Deals",
                column: "AvailableOn")
                .Annotation("Npgsql:IndexMethod", "gin");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_DealId",
                schema: "inventory",
                table: "Deals",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DealId",
                schema: "inventory",
                table: "Products",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "inventory",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnitQuantity_UnitId",
                schema: "inventory",
                table: "ProductUnitQuantity",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProduct_ProductId",
                schema: "inventory",
                table: "ServiceProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProduct_ServiceId",
                schema: "inventory",
                table: "ServiceProduct",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DealId",
                schema: "inventory",
                table: "Services",
                column: "DealId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "CategoryService",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "ProductUnitQuantity",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "ServiceProduct",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Deals",
                schema: "inventory");
        }
    }
}
