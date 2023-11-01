using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class changeEntityConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact Person_Clients_ClientId",
                table: "Contact Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Clients_ClientId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Orders_OrderId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Contract_ContractId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contract_ContractId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact Person_Clients_ClientId",
                table: "Contact Person",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Clients_ClientId",
                table: "Contract",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Orders_OrderId",
                table: "Documents",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Contract_ContractId",
                table: "Invoices",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contract_ContractId",
                table: "Orders",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact Person_Clients_ClientId",
                table: "Contact Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Clients_ClientId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Orders_OrderId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Contract_ContractId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Contract_ContractId",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact Person_Clients_ClientId",
                table: "Contact Person",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Clients_ClientId",
                table: "Contract",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Orders_OrderId",
                table: "Documents",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Contract_ContractId",
                table: "Invoices",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Contract_ContractId",
                table: "Orders",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
