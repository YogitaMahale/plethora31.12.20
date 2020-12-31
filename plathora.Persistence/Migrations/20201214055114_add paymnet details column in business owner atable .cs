using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addpaymnetdetailscolumninbusinessowneratable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Expirydate",
                table: "BusinessOwnerRegi",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MembershipId",
                table: "BusinessOwnerRegi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentAmount",
                table: "BusinessOwnerRegi",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registrationdate",
                table: "BusinessOwnerRegi",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "BusinessOwnerRegi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expirydate",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "MembershipId",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "Registrationdate",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "BusinessOwnerRegi");
        }
    }
}
