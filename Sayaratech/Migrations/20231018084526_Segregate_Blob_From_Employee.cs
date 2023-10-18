using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sayaratech.Migrations
{
    /// <inheritdoc />
    public partial class SegregateBlobFromEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                schema: "Sayaratech",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                schema: "Sayaratech",
                table: "Employees",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
