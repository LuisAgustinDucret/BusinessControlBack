using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessControlBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Rubro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "UnidadMedida",
                newName: "Description");

            migrationBuilder.CreateTable(
                name: "Rubro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubro", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rubro");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "UnidadMedida",
                newName: "Type");
        }
    }
}
