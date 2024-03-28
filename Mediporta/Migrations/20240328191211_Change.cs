using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediporta.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Collectives_CollectiveId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CollectiveId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CollectiveId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "CollectiveModelTagModel",
                columns: table => new
                {
                    CollectiveId = table.Column<int>(type: "integer", nullable: false),
                    TagsTagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectiveModelTagModel", x => new { x.CollectiveId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_CollectiveModelTagModel_Collectives_CollectiveId",
                        column: x => x.CollectiveId,
                        principalTable: "Collectives",
                        principalColumn: "CollectiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CollectiveModelTagModel_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectiveModelTagModel_TagsTagId",
                table: "CollectiveModelTagModel",
                column: "TagsTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectiveModelTagModel");

            migrationBuilder.AddColumn<int>(
                name: "CollectiveId",
                table: "Tags",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CollectiveId",
                table: "Tags",
                column: "CollectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Collectives_CollectiveId",
                table: "Tags",
                column: "CollectiveId",
                principalTable: "Collectives",
                principalColumn: "CollectiveId");
        }
    }
}
