using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addBusinessPackageIdinbusinessownereRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_Membership_MembershipId",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOwnerRegi_MembershipId",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "BusinessOwnerRegi");

            migrationBuilder.AddColumn<int>(
                name: "BusinessPackageId",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "accountname",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "accountno",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankname",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "branch",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cityid",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "companyName",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "designation",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gstno",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "house",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ifsccode",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "landmark",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "passbookphoto",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "zipcode",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOwnerRegi_BusinessPackageId",
                table: "BusinessOwnerRegi",
                column: "BusinessPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOwnerRegi_cityid",
                table: "BusinessOwnerRegi",
                column: "cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_BusinessPackage_BusinessPackageId",
                table: "BusinessOwnerRegi",
                column: "BusinessPackageId",
                principalTable: "BusinessPackage",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_cityRegistrations_cityid",
                table: "BusinessOwnerRegi",
                column: "cityid",
                principalTable: "cityRegistrations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_BusinessPackage_BusinessPackageId",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_cityRegistrations_cityid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOwnerRegi_BusinessPackageId",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOwnerRegi_cityid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "BusinessPackageId",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "BusinessOwnerRegi");

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
                name: "cityid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "companyName",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "designation",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "gstno",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "house",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "ifsccode",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "landmark",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "passbookphoto",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "street",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "zipcode",
                table: "BusinessOwnerRegi");

            migrationBuilder.AddColumn<int>(
                name: "MembershipId",
                table: "BusinessOwnerRegi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOwnerRegi_MembershipId",
                table: "BusinessOwnerRegi",
                column: "MembershipId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_Membership_MembershipId",
                table: "BusinessOwnerRegi",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
