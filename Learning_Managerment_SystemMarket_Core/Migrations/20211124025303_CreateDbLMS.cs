using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_Managerment_SystemMarket_Core.Migrations
{
    public partial class CreateDbLMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Students",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "FistName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FistName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Students",
                newName: "StudentName");

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
