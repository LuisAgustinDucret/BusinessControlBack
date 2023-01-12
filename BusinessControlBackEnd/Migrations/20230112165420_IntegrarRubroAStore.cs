using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessControlBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class IntegrarRubroAStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RubroId",
                table: "Store",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Store_RubroId",
                table: "Store",
                column: "RubroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Rubro_RubroId",
                table: "Store",
                column: "RubroId",
                principalTable: "Rubro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Rubro_RubroId",
                table: "Store");

            migrationBuilder.DropIndex(
                name: "IX_Store_RubroId",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "RubroId",
                table: "Store");
        }
    }
}
