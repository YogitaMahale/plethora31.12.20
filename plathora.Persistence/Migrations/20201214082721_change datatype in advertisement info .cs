using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class changedatatypeinadvertisementinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisementInfos_AspNetUsers_cusotmerid",
                table: "advertisementInfos");

            migrationBuilder.DropIndex(
                name: "IX_advertisementInfos_cusotmerid",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "cusotmerid",
                table: "advertisementInfos");

            migrationBuilder.AddColumn<string>(
                name: "customerId",
                table: "advertisementInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_advertisementInfos_customerId",
                table: "advertisementInfos",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisementInfos_AspNetUsers_customerId",
                table: "advertisementInfos",
                column: "customerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisementInfos_AspNetUsers_customerId",
                table: "advertisementInfos");

            migrationBuilder.DropIndex(
                name: "IX_advertisementInfos_customerId",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "advertisementInfos");

            migrationBuilder.AddColumn<string>(
                name: "cusotmerid",
                table: "advertisementInfos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_advertisementInfos_cusotmerid",
                table: "advertisementInfos",
                column: "cusotmerid");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisementInfos_AspNetUsers_cusotmerid",
                table: "advertisementInfos",
                column: "cusotmerid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
