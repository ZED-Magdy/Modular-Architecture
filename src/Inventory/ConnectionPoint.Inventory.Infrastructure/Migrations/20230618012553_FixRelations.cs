using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionPoint.Inventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributeValue_ProductVariations_ProductVariationId",
                schema: "inventory",
                table: "ProductAttributeValue");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariations_Products_ProductId",
                schema: "inventory",
                table: "ProductVariations");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributeValue_ProductVariationId",
                schema: "inventory",
                table: "ProductAttributeValue");

            migrationBuilder.DropColumn(
                name: "ProductVariationId",
                schema: "inventory",
                table: "ProductAttributeValue");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                schema: "inventory",
                table: "ProductVariations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ProductAttributeValueProductVariation",
                schema: "inventory",
                columns: table => new
                {
                    AttributeValuesId = table.Column<Guid>(type: "uuid", nullable: false),
                    VariationsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeValueProductVariation", x => new { x.AttributeValuesId, x.VariationsId });
                    table.ForeignKey(
                        name: "FK_ProductAttributeValueProductVariation_ProductAttributeValue~",
                        column: x => x.AttributeValuesId,
                        principalSchema: "inventory",
                        principalTable: "ProductAttributeValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAttributeValueProductVariation_ProductVariations_Var~",
                        column: x => x.VariationsId,
                        principalSchema: "inventory",
                        principalTable: "ProductVariations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeValueProductVariation_VariationsId",
                schema: "inventory",
                table: "ProductAttributeValueProductVariation",
                column: "VariationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariations_Products_ProductId",
                schema: "inventory",
                table: "ProductVariations",
                column: "ProductId",
                principalSchema: "inventory",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariations_Products_ProductId",
                schema: "inventory",
                table: "ProductVariations");

            migrationBuilder.DropTable(
                name: "ProductAttributeValueProductVariation",
                schema: "inventory");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                schema: "inventory",
                table: "ProductVariations",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductVariationId",
                schema: "inventory",
                table: "ProductAttributeValue",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeValue_ProductVariationId",
                schema: "inventory",
                table: "ProductAttributeValue",
                column: "ProductVariationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributeValue_ProductVariations_ProductVariationId",
                schema: "inventory",
                table: "ProductAttributeValue",
                column: "ProductVariationId",
                principalSchema: "inventory",
                principalTable: "ProductVariations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariations_Products_ProductId",
                schema: "inventory",
                table: "ProductVariations",
                column: "ProductId",
                principalSchema: "inventory",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
