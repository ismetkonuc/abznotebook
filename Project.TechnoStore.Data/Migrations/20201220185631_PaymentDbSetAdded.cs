using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.TechnoStore.Data.Migrations
{
    public partial class PaymentDbSetAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payment_PaymentId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payment_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
