using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amortization.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MortgageParameters",
                columns: table => new
                {
                    MortgageParameterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrincipalLoanAmount = table.Column<double>(type: "float", nullable: false),
                    AnnualInterestRate = table.Column<double>(type: "float", nullable: false),
                    NumberOfPayments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageParameters", x => x.MortgageParameterId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MortgageParameters");
        }
    }
}
