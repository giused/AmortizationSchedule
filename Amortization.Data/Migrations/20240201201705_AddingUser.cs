using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amortization.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MortgageParameters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MortgageParameters_UserId",
                table: "MortgageParameters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageParameters_User_UserId",
                table: "MortgageParameters",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageParameters_User_UserId",
                table: "MortgageParameters");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_MortgageParameters_UserId",
                table: "MortgageParameters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MortgageParameters");
        }
    }
}
