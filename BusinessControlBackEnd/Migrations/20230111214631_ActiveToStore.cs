using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessControlBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class ActiveToStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Store",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Store");
        }
    }
}
