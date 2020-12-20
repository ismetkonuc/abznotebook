using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.TechnoStore.Data.Migrations
{
    public partial class AddTitleColumnInAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Addresses",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Addresses");
        }
    }
}
