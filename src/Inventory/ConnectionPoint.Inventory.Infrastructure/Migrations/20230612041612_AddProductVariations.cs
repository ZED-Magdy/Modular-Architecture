using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionPoint.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductVariations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductId",
                schema: "inventory",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnitQuantity_Products_ProductId",
                schema: "inventory",
                table: "ProductUnitQuantity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnitQuantity_Units_UnitId",
                schema: "inventory",
                table: "ProductUnitQuantity");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductId",
                schema: "inventory",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUnitQuantity",
                schema: "inventory",
                table: "ProductUnitQuantity");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "inventory",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ProductUnitQuantity",
                schema: "inventory",
                newName: "ProductUnitQuantities",
                newSchema: "inventory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUnitQuantity_UnitId",
                schema: "inventory",
                table: "ProductUnitQuantities",
                newName: "IX_ProductUnitQuantities_UnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUnitQuantities",
                schema: "inventory",
                table: "ProductUnitQuantities",
                columns: new[] { "ProductId", "UnitId" });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
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
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariations",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_ProductVariations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariations_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "inventory",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeValue",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ProductAttributeId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_ProductAttributeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeValue_ProductAttributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalSchema: "inventory",
                        principalTable: "ProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variations",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductVariationId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttributeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ValueId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_Variations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variations_ProductAttributeValue_ValueId",
                        column: x => x.ValueId,
                        principalSchema: "inventory",
                        principalTable: "ProductAttributeValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Variations_ProductAttributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "inventory",
                        principalTable: "ProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Variations_ProductVariations_ProductVariationId",
                        column: x => x.ProductVariationId,
                        principalSchema: "inventory",
                        principalTable: "ProductVariations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeValue_ProductAttributeId",
                schema: "inventory",
                table: "ProductAttributeValue",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariations_ProductId",
                schema: "inventory",
                table: "ProductVariations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_AttributeId",
                schema: "inventory",
                table: "Variations",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_ProductVariationId",
                schema: "inventory",
                table: "Variations",
                column: "ProductVariationId");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_ValueId",
                schema: "inventory",
                table: "Variations",
                column: "ValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnitQuantities_Products_ProductId",
                schema: "inventory",
                table: "ProductUnitQuantities",
                column: "ProductId",
                principalSchema: "inventory",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnitQuantities_Units_UnitId",
                schema: "inventory",
                table: "ProductUnitQuantities",
                column: "UnitId",
                principalSchema: "inventory",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnitQuantities_Products_ProductId",
                schema: "inventory",
                table: "ProductUnitQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnitQuantities_Units_UnitId",
                schema: "inventory",
                table: "ProductUnitQuantities");

            migrationBuilder.DropTable(
                name: "Variations",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "ProductAttributeValue",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "ProductVariations",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "ProductAttributes",
                schema: "inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUnitQuantities",
                schema: "inventory",
                table: "ProductUnitQuantities");

            migrationBuilder.RenameTable(
                name: "ProductUnitQuantities",
                schema: "inventory",
                newName: "ProductUnitQuantity",
                newSchema: "inventory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUnitQuantities_UnitId",
                schema: "inventory",
                table: "ProductUnitQuantity",
                newName: "IX_ProductUnitQuantity_UnitId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "inventory",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUnitQuantity",
                schema: "inventory",
                table: "ProductUnitQuantity",
                columns: new[] { "ProductId", "UnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                schema: "inventory",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductId",
                schema: "inventory",
                table: "Products",
                column: "ProductId",
                principalSchema: "inventory",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnitQuantity_Products_ProductId",
                schema: "inventory",
                table: "ProductUnitQuantity",
                column: "ProductId",
                principalSchema: "inventory",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnitQuantity_Units_UnitId",
                schema: "inventory",
                table: "ProductUnitQuantity",
                column: "UnitId",
                principalSchema: "inventory",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
