using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Image.Server.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    FileName = table.Column<string>(maxLength: 50, nullable: true),
                    ImageThumb = table.Column<byte[]>(maxLength: 50000, nullable: true),
                    ImageFull = table.Column<byte[]>(maxLength: 150000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDiscontinued = table.Column<byte>(nullable: false),
                    AssociatedCategoryId = table.Column<int>(nullable: true),
                    AssociatedSnapshotTypeId = table.Column<int>(nullable: true),
                    AssociatedGroupId = table.Column<int>(nullable: true),
                    AssociatedScreenId = table.Column<int>(nullable: true),
                    AssociatedImageId = table.Column<int>(nullable: true),
                    AssociatedRecycleId = table.Column<int>(nullable: true),
                    MerchantNumber = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    AiPartNumber = table.Column<string>(nullable: true),
                    ManufactureNumber = table.Column<string>(nullable: true),
                    ManufactureName = table.Column<string>(nullable: true),
                    MfgUrl = table.Column<string>(nullable: true),
                    MfgManualUrl = table.Column<string>(nullable: true),
                    AssociatedPrimaryVendorId = table.Column<int>(nullable: true),
                    AssociatedSecondaryVendorId = table.Column<int>(nullable: true),
                    AssociatedTertiaryVendorId = table.Column<int>(nullable: true),
                    Retail = table.Column<double>(nullable: true),
                    Cost = table.Column<double>(nullable: true),
                    AdditionalCost = table.Column<byte>(nullable: false),
                    DefaultPriority = table.Column<double>(nullable: true),
                    IsTaxable = table.Column<byte>(nullable: true),
                    IsRecycleFee = table.Column<byte>(nullable: false),
                    ItemsAssociated = table.Column<string>(nullable: true),
                    IsExcludedDesAinumOverrwrite = table.Column<sbyte>(nullable: false),
                    CostVerificationBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductImages_AssociatedImageId",
                        column: x => x.AssociatedImageId,
                        principalTable: "ProductImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AssociatedImageId",
                table: "Products",
                column: "AssociatedImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductImages");
        }
    }
}
