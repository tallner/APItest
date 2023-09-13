using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APItest.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TemplateField3",
                table: "TemplateEntities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateField3",
                table: "TemplateEntities");
        }
    }
}
