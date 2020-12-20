using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.TechnoStore.Data.Migrations
{
    public partial class DeleteAllowedColumnInPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allowed",
                table: "Payment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Allowed",
                table: "Payment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
