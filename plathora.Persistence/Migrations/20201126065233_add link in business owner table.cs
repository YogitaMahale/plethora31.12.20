using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addlinkinbusinessownertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "facebookLink",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "googleplusLink",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "instagramLink",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "linkedinLink",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "twitterLink",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "youtubeLink",
                table: "BusinessOwnerRegi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "facebookLink",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "googleplusLink",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "instagramLink",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "linkedinLink",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "twitterLink",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "youtubeLink",
                table: "BusinessOwnerRegi");
        }
    }
}
