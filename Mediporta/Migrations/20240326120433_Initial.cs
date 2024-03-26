using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mediporta.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collectives",
                columns: table => new
                {
                    CollectiveId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectives", x => x.CollectiveId);
                });

            migrationBuilder.CreateTable(
                name: "CollectiveExternalLinks",
                columns: table => new
                {
                    CollectiveExternalLinkId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Link = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CollectiveId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectiveExternalLinks", x => x.CollectiveExternalLinkId);
                    table.ForeignKey(
                        name: "FK_CollectiveExternalLinks_Collectives_CollectiveId",
                        column: x => x.CollectiveId,
                        principalTable: "Collectives",
                        principalColumn: "CollectiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    HasSynonyms = table.Column<bool>(type: "boolean", nullable: false),
                    IsModeratorOnly = table.Column<bool>(type: "boolean", nullable: false),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    LastActivityDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Synonyms = table.Column<List<string>>(type: "text[]", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    CollectiveId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_Collectives_CollectiveId",
                        column: x => x.CollectiveId,
                        principalTable: "Collectives",
                        principalColumn: "CollectiveId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollectiveExternalLinks_CollectiveId",
                table: "CollectiveExternalLinks",
                column: "CollectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CollectiveId",
                table: "Tags",
                column: "CollectiveId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollectiveExternalLinks");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Collectives");
        }
    }
}
