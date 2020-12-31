using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class addpaymentdetailsinadvertisementInfoupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "affilateid",
                table: "advertisementInfos");

            migrationBuilder.AlterColumn<string>(
                name: "cusotmerid",
                table: "advertisementInfos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "advertiseid",
                table: "advertisementInfos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expirydate",
                table: "advertisementInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentAmount",
                table: "advertisementInfos",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "advertisementInfos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Registrationdate",
                table: "advertisementInfos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "advertisementInfos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_advertisementInfos_advertiseid",
                table: "advertisementInfos",
                column: "advertiseid");

            migrationBuilder.CreateIndex(
                name: "IX_advertisementInfos_cusotmerid",
                table: "advertisementInfos",
                column: "cusotmerid");

            migrationBuilder.AddForeignKey(
                name: "FK_advertisementInfos_Advertise_advertiseid",
                table: "advertisementInfos",
                column: "advertiseid",
                principalTable: "Advertise",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_advertisementInfos_AspNetUsers_cusotmerid",
                table: "advertisementInfos",
                column: "cusotmerid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_advertisementInfos_Advertise_advertiseid",
                table: "advertisementInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_advertisementInfos_AspNetUsers_cusotmerid",
                table: "advertisementInfos");

            migrationBuilder.DropIndex(
                name: "IX_advertisementInfos_advertiseid",
                table: "advertisementInfos");

            migrationBuilder.DropIndex(
                name: "IX_advertisementInfos_cusotmerid",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "Expirydate",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "PaymentAmount",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "Registrationdate",
                table: "advertisementInfos");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "advertisementInfos");

            migrationBuilder.AlterColumn<int>(
                name: "cusotmerid",
                table: "advertisementInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "advertiseid",
                table: "advertisementInfos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "affilateid",
                table: "advertisementInfos",
                type: "int",
                nullable: true);
        }
    }
}
