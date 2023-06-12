using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectionPoint.Taxing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitTaxingModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Taxing");

            migrationBuilder.CreateTable(
                name: "Taxables",
                schema: "Taxing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxableId = table.Column<Guid>(type: "uuid", nullable: false),
                    TaxableType = table.Column<string>(type: "text", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    NetPrice = table.Column<decimal>(type: "numeric", nullable: false),
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
                    table.PrimaryKey("PK_Taxables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                schema: "Taxing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxType = table.Column<int>(type: "integer", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    TaxableId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxes_Taxables_TaxableId",
                        column: x => x.TaxableId,
                        principalSchema: "Taxing",
                        principalTable: "Taxables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_TaxableId",
                schema: "Taxing",
                table: "Taxes",
                column: "TaxableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxes",
                schema: "Taxing");

            migrationBuilder.DropTable(
                name: "Taxables",
                schema: "Taxing");
        }
    }
}
