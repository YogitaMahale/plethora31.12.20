using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class changesinbusinessownernew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_Membership_MembershipId",
                table: "BusinessOwnerRegi");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipId",
                table: "BusinessOwnerRegi",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_Membership_MembershipId",
                table: "BusinessOwnerRegi",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_Membership_MembershipId",
                table: "BusinessOwnerRegi");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipId",
                table: "BusinessOwnerRegi",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_Membership_MembershipId",
                table: "BusinessOwnerRegi",
                column: "MembershipId",
                principalTable: "Membership",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
