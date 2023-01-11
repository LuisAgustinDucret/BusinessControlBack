using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessControlBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class ActiveToUnidadMedida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "UnidadMedida",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "UnidadMedida");
        }
    }
}
