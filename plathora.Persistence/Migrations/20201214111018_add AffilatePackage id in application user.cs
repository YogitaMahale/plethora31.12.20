using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addAffilatePackageidinapplicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AffilatePackageid",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentAmount",
                table: "AspNetUsers",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AffilatePackageid",
                table: "AspNetUsers",
                column: "AffilatePackageid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AffilatePackage_AffilatePackageid",
                table: "AspNetUsers",
                column: "AffilatePackageid",
                principalTable: "AffilatePackage",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AffilatePackage_AffilatePackageid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AffilatePackageid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AffilatePackageid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "AspNetUsers");
        }
    }
}
