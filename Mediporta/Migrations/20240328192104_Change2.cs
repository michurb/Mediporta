using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mediporta.Migrations
{
    /// <inheritdoc />
    public partial class Change2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectiveExternalLinks_Collectives_CollectiveId",
                table: "CollectiveExternalLinks");

            migrationBuilder.DropTable(
                name: "CollectiveModelTagModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectiveExternalLinks",
                table: "CollectiveExternalLinks");

            migrationBuilder.DropIndex(
                name: "IX_CollectiveExternalLinks_CollectiveId",
                table: "CollectiveExternalLinks");

            migrationBuilder.DropColumn(
                name: "CollectiveExternalLinkId",
                table: "CollectiveExternalLinks");

            migrationBuilder.DropColumn(
                name: "CollectiveId",
                table: "CollectiveExternalLinks");

            migrationBuilder.AddColumn<int>(
                name: "TagModelTagId",
                table: "Collectives",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "CollectiveExternalLinks",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "CollectiveModelCollectiveId",
                table: "CollectiveExternalLinks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectiveExternalLinks",
                table: "CollectiveExternalLinks",
                column: "Link");

            migrationBuilder.CreateIndex(
                name: "IX_Collectives_TagModelTagId",
                table: "Collectives",
                column: "TagModelTagId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectiveExternalLinks_CollectiveModelCollectiveId",
                table: "CollectiveExternalLinks",
                column: "CollectiveModelCollectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectiveExternalLinks_Collectives_CollectiveModelCollecti~",
                table: "CollectiveExternalLinks",
                column: "CollectiveModelCollectiveId",
                principalTable: "Collectives",
                principalColumn: "CollectiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collectives_Tags_TagModelTagId",
                table: "Collectives",
                column: "TagModelTagId",
                principalTable: "Tags",
                principalColumn: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectiveExternalLinks_Collectives_CollectiveModelCollecti~",
                table: "CollectiveExternalLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Collectives_Tags_TagModelTagId",
                table: "Collectives");

            migrationBuilder.DropIndex(
                name: "IX_Collectives_TagModelTagId",
                table: "Collectives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectiveExternalLinks",
                table: "CollectiveExternalLinks");

            migrationBuilder.DropIndex(
                name: "IX_CollectiveExternalLinks_CollectiveModelCollectiveId",
                table: "CollectiveExternalLinks");

            migrationBuilder.DropColumn(
                name: "TagModelTagId",
                table: "Collectives");

            migrationBuilder.DropColumn(
                name: "CollectiveModelCollectiveId",
                table: "CollectiveExternalLinks");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "CollectiveExternalLinks",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "CollectiveExternalLinkId",
                table: "CollectiveExternalLinks",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CollectiveId",
                table: "CollectiveExternalLinks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectiveExternalLinks",
                table: "CollectiveExternalLinks",
                column: "CollectiveExternalLinkId");

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
                name: "IX_CollectiveExternalLinks_CollectiveId",
                table: "CollectiveExternalLinks",
                column: "CollectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectiveModelTagModel_TagsTagId",
                table: "CollectiveModelTagModel",
                column: "TagsTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectiveExternalLinks_Collectives_CollectiveId",
                table: "CollectiveExternalLinks",
                column: "CollectiveId",
                principalTable: "Collectives",
                principalColumn: "CollectiveId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
