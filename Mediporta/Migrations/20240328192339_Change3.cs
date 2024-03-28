using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mediporta.Migrations
{
    /// <inheritdoc />
    public partial class Change3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectiveExternalLinks",
                table: "CollectiveExternalLinks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CollectiveExternalLinks",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectiveExternalLinks",
                table: "CollectiveExternalLinks",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CollectiveExternalLinks",
                table: "CollectiveExternalLinks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CollectiveExternalLinks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CollectiveExternalLinks",
                table: "CollectiveExternalLinks",
                column: "Link");
        }
    }
}
