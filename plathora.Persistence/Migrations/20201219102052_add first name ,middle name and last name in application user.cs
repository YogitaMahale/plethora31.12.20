using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addfirstnamemiddlenameandlastnameinapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Membership_Membershipid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_cityRegistrations_cityid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Membershipid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_cityid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "designation",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "Membershipid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "amount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "cityid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "companyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "designation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "gstno",
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

            migrationBuilder.AddColumn<string>(
                name: "businessOperation",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "businessType",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "businessOperation",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "businessType",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "designation",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Membershipid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "amount",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cityid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "companyName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "designation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gstno",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "house",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "landmark",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "zipcode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Membershipid",
                table: "AspNetUsers",
                column: "Membershipid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_cityid",
                table: "AspNetUsers",
                column: "cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Membership_Membershipid",
                table: "AspNetUsers",
                column: "Membershipid",
                principalTable: "Membership",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_cityRegistrations_cityid",
                table: "AspNetUsers",
                column: "cityid",
                principalTable: "cityRegistrations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
