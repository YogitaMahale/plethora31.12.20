using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class changesinbusinessowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmount",
                table: "BusinessOwnerRegi",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_Membership_MembershipId",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOwnerRegi_MembershipId",
                table: "BusinessOwnerRegi");

            migrationBuilder.AlterColumn<decimal>(
                name: "PaymentAmount",
                table: "BusinessOwnerRegi",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");
        }
    }
}
