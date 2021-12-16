using Microsoft.EntityFrameworkCore.Migrations;

namespace Mohandisy.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "ServiceProviderProfiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "ServiceProviderProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
