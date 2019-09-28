using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetacademyaspmvc.Migrations
{
    public partial class AddLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Markers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Markers");
        }
    }
}
