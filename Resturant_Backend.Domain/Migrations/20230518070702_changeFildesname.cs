using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturant_Backend.Domain.Migrations
{
    /// <inheritdoc />
    public partial class changeFildesname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeliveryByCompany",
                table: "Factors",
                newName: "IsDeliveryByCompanyPaid");

            migrationBuilder.RenameColumn(
                name: "FactorNummber",
                table: "Factors",
                newName: "FactorNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeliveryByCompanyPaid",
                table: "Factors",
                newName: "IsDeliveryByCompany");

            migrationBuilder.RenameColumn(
                name: "FactorNumber",
                table: "Factors",
                newName: "FactorNummber");
        }
    }
}
