using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sayaratech.Migrations
{
    /// <inheritdoc />
    public partial class PhysicalFileIndicator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPhysicalFile",
                schema: "Sayaratech",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPhysicalFile",
                schema: "Sayaratech",
                table: "Employees");
        }
    }
}
