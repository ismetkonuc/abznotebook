using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.TechnoStore.Data.Migrations
{
    public partial class AddNeighborhoodColumnInAddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Addresses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Addresses");
        }
    }
}
