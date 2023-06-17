using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionPoint.Voucher.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscuntableRelationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "voucher");

            migrationBuilder.CreateTable(
                name: "Discountables",
                schema: "voucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountableId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountableType = table.Column<string>(type: "text", nullable: false),
                    NetPrice = table.Column<double>(type: "double precision", nullable: false),
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
                    table.PrimaryKey("PK_Discountables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CouponDiscountable",
                schema: "voucher",
                columns: table => new
                {
                    CouponsId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiscountablesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponDiscountable", x => new { x.CouponsId, x.DiscountablesId });
                    table.ForeignKey(
                        name: "FK_CouponDiscountable_Coupons_CouponsId",
                        column: x => x.CouponsId,
                        principalSchema: "voucher",
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponDiscountable_Discountables_DiscountablesId",
                        column: x => x.DiscountablesId,
                        principalSchema: "voucher",
                        principalTable: "Discountables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponDiscountable_DiscountablesId",
                schema: "voucher",
                table: "CouponDiscountable",
                column: "DiscountablesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponDiscountable",
                schema: "voucher");

            migrationBuilder.DropTable(
                name: "Coupons",
                schema: "voucher");

            migrationBuilder.DropTable(
                name: "Discountables",
                schema: "voucher");
        }
    }
}
