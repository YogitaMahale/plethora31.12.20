using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addhouselandmarkcityzipcodeinapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cityid",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "house",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "landmark",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "zipcode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_cityid",
                table: "AspNetUsers",
                column: "cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_cityRegistrations_cityid",
                table: "AspNetUsers",
                column: "cityid",
                principalTable: "cityRegistrations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_cityRegistrations_cityid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_cityid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "cityid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "house",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "landmark",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "street",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "zipcode",
                table: "AspNetUsers");
        }
    }
}
