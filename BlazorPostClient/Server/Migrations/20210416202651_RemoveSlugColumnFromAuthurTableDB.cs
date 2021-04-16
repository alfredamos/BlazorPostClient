using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorPostClient.Server.Migrations
{
    public partial class RemoveSlugColumnFromAuthurTableDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
