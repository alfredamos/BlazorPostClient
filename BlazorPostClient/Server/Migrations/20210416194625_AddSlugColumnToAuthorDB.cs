using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorPostClient.Server.Migrations
{
    public partial class AddSlugColumnToAuthorDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Authors");
        }
    }
}
