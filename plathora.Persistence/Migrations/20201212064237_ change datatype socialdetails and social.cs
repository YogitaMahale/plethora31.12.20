using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class changedatatypesocialdetailsandsocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_socials_CustomerRegistration_customerid",
                table: "socials");

            migrationBuilder.DropIndex(
                name: "IX_socials_customerid",
                table: "socials");

            migrationBuilder.AlterColumn<string>(
                name: "customerid",
                table: "socials",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "customerid",
                table: "socialdetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "customerid",
                table: "socials",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "customerid",
                table: "socialdetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_socials_customerid",
                table: "socials",
                column: "customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_socials_CustomerRegistration_customerid",
                table: "socials",
                column: "customerid",
                principalTable: "CustomerRegistration",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
