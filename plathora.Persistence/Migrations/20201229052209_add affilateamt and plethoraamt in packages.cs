using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addaffilateamtandplethoraamtinpackages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "affilateamt",
                table: "BusinessPackage",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plethoraamt",
                table: "BusinessPackage",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "affilateamt",
                table: "AffilatePackage",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plethoraamt",
                table: "AffilatePackage",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "affilateamt",
                table: "Advertise",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "plethoraamt",
                table: "Advertise",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "affilateamt",
                table: "BusinessPackage");

            migrationBuilder.DropColumn(
                name: "plethoraamt",
                table: "BusinessPackage");

            migrationBuilder.DropColumn(
                name: "affilateamt",
                table: "AffilatePackage");

            migrationBuilder.DropColumn(
                name: "plethoraamt",
                table: "AffilatePackage");

            migrationBuilder.DropColumn(
                name: "affilateamt",
                table: "Advertise");

            migrationBuilder.DropColumn(
                name: "plethoraamt",
                table: "Advertise");
        }
    }
}
