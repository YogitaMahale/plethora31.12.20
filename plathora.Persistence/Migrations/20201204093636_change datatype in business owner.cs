using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class changedatatypeinbusinessowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_ProductMaster_productid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOwnerRegi_productid",
                table: "BusinessOwnerRegi");

            migrationBuilder.AlterColumn<string>(
                name: "productid",
                table: "BusinessOwnerRegi",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "productid",
                table: "BusinessOwnerRegi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOwnerRegi_productid",
                table: "BusinessOwnerRegi",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_ProductMaster_productid",
                table: "BusinessOwnerRegi",
                column: "productid",
                principalTable: "ProductMaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
