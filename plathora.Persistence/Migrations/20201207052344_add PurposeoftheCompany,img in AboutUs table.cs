using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addPurposeoftheCompanyimginAboutUstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurposeoftheCompany",
                table: "AboutUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "AboutUs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurposeoftheCompany",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "img",
                table: "AboutUs");
        }
    }
}
