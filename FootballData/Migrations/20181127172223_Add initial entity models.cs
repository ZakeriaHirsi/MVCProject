using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballData.Migrations
{
    public partial class Addinitialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StadiumBranchID",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StadiumCardID",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StadiumBranches",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StadiumBranches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StadiumCards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fees = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StadiumCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchID = table.Column<int>(nullable: true),
                    DayOfWeek = table.Column<int>(nullable: false),
                    OpenTime = table.Column<int>(nullable: false),
                    CloseTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BranchHours_StadiumBranches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "StadiumBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StadiumAssets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    LocationID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    DeweyIndex = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StadiumAssets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StadiumAssets_StadiumBranches_LocationID",
                        column: x => x.LocationID,
                        principalTable: "StadiumBranches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StadiumAssets_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StadiumAssetID = table.Column<int>(nullable: false),
                    StadiumCardID = table.Column<int>(nullable: false),
                    CheckedOut = table.Column<DateTime>(nullable: false),
                    CheckedIn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_StadiumAssets_StadiumAssetID",
                        column: x => x.StadiumAssetID,
                        principalTable: "StadiumAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_StadiumCards_StadiumCardID",
                        column: x => x.StadiumCardID,
                        principalTable: "StadiumCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StadiumAssetID = table.Column<int>(nullable: false),
                    StadiumCardID = table.Column<int>(nullable: true),
                    CheckedOut = table.Column<DateTime>(nullable: false),
                    Due = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Checkouts_StadiumAssets_StadiumAssetID",
                        column: x => x.StadiumAssetID,
                        principalTable: "StadiumAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Checkouts_StadiumCards_StadiumCardID",
                        column: x => x.StadiumCardID,
                        principalTable: "StadiumCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StadiumAssetID = table.Column<int>(nullable: true),
                    StadiumCardID = table.Column<int>(nullable: true),
                    HoldPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Holds_StadiumAssets_StadiumAssetID",
                        column: x => x.StadiumAssetID,
                        principalTable: "StadiumAssets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_StadiumCards_StadiumCardID",
                        column: x => x.StadiumCardID,
                        principalTable: "StadiumCards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_StadiumBranchID",
                table: "Users",
                column: "StadiumBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StadiumCardID",
                table: "Users",
                column: "StadiumCardID");

            migrationBuilder.CreateIndex(
                name: "IX_BranchHours_BranchID",
                table: "BranchHours",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_StadiumAssetID",
                table: "CheckoutHistories",
                column: "StadiumAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_StadiumCardID",
                table: "CheckoutHistories",
                column: "StadiumCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_StadiumAssetID",
                table: "Checkouts",
                column: "StadiumAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_StadiumCardID",
                table: "Checkouts",
                column: "StadiumCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_StadiumAssetID",
                table: "Holds",
                column: "StadiumAssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_StadiumCardID",
                table: "Holds",
                column: "StadiumCardID");

            migrationBuilder.CreateIndex(
                name: "IX_StadiumAssets_LocationID",
                table: "StadiumAssets",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_StadiumAssets_StatusID",
                table: "StadiumAssets",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StadiumBranches_StadiumBranchID",
                table: "Users",
                column: "StadiumBranchID",
                principalTable: "StadiumBranches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StadiumCards_StadiumCardID",
                table: "Users",
                column: "StadiumCardID",
                principalTable: "StadiumCards",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StadiumBranches_StadiumBranchID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StadiumCards_StadiumCardID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "StadiumAssets");

            migrationBuilder.DropTable(
                name: "StadiumCards");

            migrationBuilder.DropTable(
                name: "StadiumBranches");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Users_StadiumBranchID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StadiumCardID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StadiumBranchID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StadiumCardID",
                table: "Users");
        }
    }
}
