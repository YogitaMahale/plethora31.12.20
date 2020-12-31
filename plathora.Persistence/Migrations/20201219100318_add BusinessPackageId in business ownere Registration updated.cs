using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addBusinessPackageIdinbusinessownereRegistrationupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "accountname",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "accountno",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "bankname",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "branch",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "ifsccode",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "passbookphoto",
                table: "BusinessOwnerRegi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "accountname",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "accountno",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankname",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ifsccode",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "passbookphoto",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
