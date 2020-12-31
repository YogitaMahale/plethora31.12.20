using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class updatebusinessownerdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_cityRegistrations_cityid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_CustomerRegistration_customerid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOwnerRegi_cityid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "adharcardno",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "adharcardphoto",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "cityid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "companyName",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "createddate",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "designation",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "deviceid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "emailid1",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "emailid2",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "gstno",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "house",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "isactive",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "isdeleted",
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
                name: "mobileno1",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "mobileno2",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "name",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "pancardno",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "pancardphoto",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "password",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "pinno",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "profilephoto",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "registerbyAffilateID",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "street",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "zipcode",
                table: "BusinessOwnerRegi");

            migrationBuilder.AlterColumn<int>(
                name: "productid",
                table: "BusinessOwnerRegi",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "customerid",
                table: "BusinessOwnerRegi",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "BusinessOwnerRegi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOwnerRegi_productid",
                table: "BusinessOwnerRegi",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_AspNetUsers_customerid",
                table: "BusinessOwnerRegi",
                column: "customerid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_ProductMaster_productid",
                table: "BusinessOwnerRegi",
                column: "productid",
                principalTable: "ProductMaster",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_AspNetUsers_customerid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropForeignKey(
                name: "FK_BusinessOwnerRegi_ProductMaster_productid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropIndex(
                name: "IX_BusinessOwnerRegi_productid",
                table: "BusinessOwnerRegi");

            migrationBuilder.DropColumn(
                name: "description",
                table: "BusinessOwnerRegi");

            migrationBuilder.AlterColumn<string>(
                name: "productid",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "customerid",
                table: "BusinessOwnerRegi",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "BusinessOwnerRegi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "adharcardno",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "adharcardphoto",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cityid",
                table: "BusinessOwnerRegi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "companyName",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "BusinessOwnerRegi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "designation",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deviceid",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emailid1",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emailid2",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gstno",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "house",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                table: "BusinessOwnerRegi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isdeleted",
                table: "BusinessOwnerRegi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "landmark",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "latitude",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "longitude",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mobileno1",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mobileno2",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pancardno",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pancardphoto",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pinno",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "profilephoto",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "registerbyAffilateID",
                table: "BusinessOwnerRegi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "zipcode",
                table: "BusinessOwnerRegi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOwnerRegi_cityid",
                table: "BusinessOwnerRegi",
                column: "cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_cityRegistrations_cityid",
                table: "BusinessOwnerRegi",
                column: "cityid",
                principalTable: "cityRegistrations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessOwnerRegi_CustomerRegistration_customerid",
                table: "BusinessOwnerRegi",
                column: "customerid",
                principalTable: "CustomerRegistration",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
