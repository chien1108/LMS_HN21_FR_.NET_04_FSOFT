using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_Managerment_SystemMarket_Core.Migrations
{
    public partial class UpdateDbRoleClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RoleClaims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RoleClaims");
        }
    }
}
