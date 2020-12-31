using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace plathora.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertise",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    description = table.Column<string>(nullable: false),
                    period = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertise", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "advertisementInfos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    affilateid = table.Column<int>(nullable: true),
                    cusotmerid = table.Column<int>(nullable: false),
                    advertiseid = table.Column<int>(nullable: false),
                    startdate = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    videourl = table.Column<string>(nullable: true),
                    shortdesc = table.Column<string>(nullable: true),
                    longdesc = table.Column<string>(nullable: true),
                    image1 = table.Column<string>(nullable: true),
                    image2 = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advertisementInfos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankRegistration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "businessratings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: true),
                    BusinessOwnerId = table.Column<int>(nullable: true),
                    rating = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businessratings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "commission",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commissionper = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CountryRegistrations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryname = table.Column<string>(nullable: false),
                    countrycode = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryRegistrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    profilephoto = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    mobileno1 = table.Column<string>(nullable: false),
                    mobileno2 = table.Column<string>(nullable: true),
                    emailid1 = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    createddate = table.Column<DateTime>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false),
                    deviceid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRegistration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "distance",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    range = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "emp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empname = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emp", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membershipName = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "moduleMasters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleMasters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PackageRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageRegistration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<int>(nullable: true),
                    affilateid = table.Column<int>(nullable: true),
                    ratingg = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SectorRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorRegistration", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sliders",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sliders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "socialdetails",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    socialid = table.Column<int>(nullable: false),
                    customerid = table.Column<int>(nullable: false),
                    LikeCnt = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socialdetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tax",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    percentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tax", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblfeedback",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true),
                    img = table.Column<string>(nullable: true),
                    customerid = table.Column<int>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblfeedback", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StateRegistrations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryid = table.Column<int>(nullable: false),
                    StateName = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateRegistrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_StateRegistrations_CountryRegistrations_countryid",
                        column: x => x.countryid,
                        principalTable: "CountryRegistrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "socials",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<int>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_socials", x => x.id);
                    table.ForeignKey(
                        name: "FK_socials_CustomerRegistration_customerid",
                        column: x => x.customerid,
                        principalTable: "CustomerRegistration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffilatePackage",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membershipid = table.Column<int>(nullable: false),
                    commissionid = table.Column<int>(nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffilatePackage", x => x.id);
                    table.ForeignKey(
                        name: "FK_AffilatePackage_commission_commissionid",
                        column: x => x.commissionid,
                        principalTable: "commission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffilatePackage_Membership_membershipid",
                        column: x => x.membershipid,
                        principalTable: "Membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkmoduleid = table.Column<int>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    videoName = table.Column<string>(nullable: true),
                    videoLink = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.id);
                    table.ForeignKey(
                        name: "FK_videos_moduleMasters_fkmoduleid",
                        column: x => x.fkmoduleid,
                        principalTable: "moduleMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessPackage",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pkgId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    description = table.Column<string>(nullable: false),
                    period = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPackage", x => x.id);
                    table.ForeignKey(
                        name: "FK_BusinessPackage_PackageRegistration_pkgId",
                        column: x => x.pkgId,
                        principalTable: "PackageRegistration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessRegistration",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sectorid = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessRegistration", x => x.id);
                    table.ForeignKey(
                        name: "FK_BusinessRegistration_SectorRegistration_sectorid",
                        column: x => x.sectorid,
                        principalTable: "SectorRegistration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cityRegistrations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stateid = table.Column<int>(nullable: false),
                    cityName = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityRegistrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_cityRegistrations_StateRegistrations_stateid",
                        column: x => x.stateid,
                        principalTable: "StateRegistrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMaster",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    businessid = table.Column<int>(nullable: false),
                    productName = table.Column<string>(nullable: false),
                    img = table.Column<string>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaster", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductMaster_BusinessRegistration_businessid",
                        column: x => x.businessid,
                        principalTable: "BusinessRegistration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiltateRegistrations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    profilephoto = table.Column<string>(nullable: true),
                    mobileno1 = table.Column<string>(nullable: false),
                    mobileno2 = table.Column<string>(nullable: true),
                    emailid1 = table.Column<string>(nullable: true),
                    emailid2 = table.Column<string>(nullable: true),
                    adharcardno = table.Column<string>(nullable: true),
                    adharcardphoto = table.Column<string>(nullable: true),
                    pancardno = table.Column<string>(nullable: true),
                    pancardphoto = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    createddate = table.Column<DateTime>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false),
                    house = table.Column<string>(nullable: true),
                    landmark = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    cityid = table.Column<int>(nullable: false),
                    zipcode = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    designation = table.Column<string>(nullable: true),
                    gstno = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    bankname = table.Column<string>(nullable: true),
                    accountname = table.Column<string>(nullable: true),
                    accountno = table.Column<string>(nullable: true),
                    ifsccode = table.Column<string>(nullable: true),
                    branch = table.Column<string>(nullable: true),
                    passbookphoto = table.Column<string>(nullable: true),
                    Membershipid = table.Column<int>(nullable: false),
                    amount = table.Column<string>(nullable: true),
                    registerbyAffilateID = table.Column<int>(nullable: false),
                    deviceid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiltateRegistrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_affiltateRegistrations_Membership_Membershipid",
                        column: x => x.Membershipid,
                        principalTable: "Membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_affiltateRegistrations_cityRegistrations_cityid",
                        column: x => x.cityid,
                        principalTable: "cityRegistrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    profilephoto = table.Column<string>(nullable: true),
                    mobileno2 = table.Column<string>(nullable: true),
                    emailid2 = table.Column<string>(nullable: true),
                    adharcardno = table.Column<string>(nullable: true),
                    adharcardphoto = table.Column<string>(nullable: true),
                    pancardno = table.Column<string>(nullable: true),
                    pancardphoto = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: true),
                    createddate = table.Column<DateTime>(nullable: true),
                    isdeleted = table.Column<bool>(nullable: true),
                    house = table.Column<string>(nullable: true),
                    landmark = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    cityid = table.Column<int>(nullable: true),
                    zipcode = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    designation = table.Column<string>(nullable: true),
                    gstno = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    bankname = table.Column<string>(nullable: true),
                    accountname = table.Column<string>(nullable: true),
                    accountno = table.Column<string>(nullable: true),
                    ifsccode = table.Column<string>(nullable: true),
                    branch = table.Column<string>(nullable: true),
                    passbookphoto = table.Column<string>(nullable: true),
                    Membershipid = table.Column<int>(nullable: true),
                    registerbyAffilateID = table.Column<string>(nullable: true),
                    amount = table.Column<string>(nullable: true),
                    deviceid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Membership_Membershipid",
                        column: x => x.Membershipid,
                        principalTable: "Membership",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_cityRegistrations_cityid",
                        column: x => x.cityid,
                        principalTable: "cityRegistrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessOwnerRegi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    profilephoto = table.Column<string>(nullable: true),
                    mobileno1 = table.Column<string>(nullable: false),
                    mobileno2 = table.Column<string>(nullable: true),
                    emailid1 = table.Column<string>(nullable: true),
                    emailid2 = table.Column<string>(nullable: true),
                    adharcardno = table.Column<string>(nullable: true),
                    adharcardphoto = table.Column<string>(nullable: true),
                    pancardno = table.Column<string>(nullable: true),
                    pancardphoto = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false),
                    gender = table.Column<string>(nullable: false),
                    pinno = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    createddate = table.Column<DateTime>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false),
                    house = table.Column<string>(nullable: true),
                    landmark = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    cityid = table.Column<int>(nullable: false),
                    zipcode = table.Column<string>(nullable: true),
                    latitude = table.Column<string>(nullable: true),
                    longitude = table.Column<string>(nullable: true),
                    companyName = table.Column<string>(nullable: true),
                    designation = table.Column<string>(nullable: true),
                    gstno = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    Regcertificate = table.Column<string>(nullable: true),
                    businessid = table.Column<string>(nullable: true),
                    productid = table.Column<string>(nullable: true),
                    lic = table.Column<string>(nullable: true),
                    registerbyAffilateID = table.Column<int>(nullable: false),
                    deviceid = table.Column<string>(nullable: true),
                    customerid = table.Column<int>(nullable: true),
                    MondayOpen = table.Column<string>(nullable: true),
                    MondayClose = table.Column<string>(nullable: true),
                    TuesdayOpen = table.Column<string>(nullable: true),
                    TuesdayClose = table.Column<string>(nullable: true),
                    WednesdayOpen = table.Column<string>(nullable: true),
                    WednesdayClose = table.Column<string>(nullable: true),
                    ThursdayOpen = table.Column<string>(nullable: true),
                    ThursdayClose = table.Column<string>(nullable: true),
                    FridayOpen = table.Column<string>(nullable: true),
                    FridayClose = table.Column<string>(nullable: true),
                    SaturdayOpen = table.Column<string>(nullable: true),
                    SaturdayClose = table.Column<string>(nullable: true),
                    SundayOpen = table.Column<string>(nullable: true),
                    SundayClose = table.Column<string>(nullable: true),
                    CallCount = table.Column<int>(nullable: false),
                    SMSCount = table.Column<int>(nullable: false),
                    WhatssappCount = table.Column<int>(nullable: false),
                    ShareCount = table.Column<int>(nullable: false),
                    sliderimg1 = table.Column<string>(nullable: true),
                    sliderimg2 = table.Column<string>(nullable: true),
                    sliderimg3 = table.Column<string>(nullable: true),
                    sliderimg4 = table.Column<string>(nullable: true),
                    sliderimg5 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessOwnerRegi", x => x.id);
                    table.ForeignKey(
                        name: "FK_BusinessOwnerRegi_cityRegistrations_cityid",
                        column: x => x.cityid,
                        principalTable: "cityRegistrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessOwnerRegi_CustomerRegistration_customerid",
                        column: x => x.customerid,
                        principalTable: "CustomerRegistration",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Taluka",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityid = table.Column<int>(nullable: false),
                    talukaname = table.Column<string>(nullable: false),
                    isdeleted = table.Column<bool>(nullable: false),
                    isactive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taluka", x => x.id);
                    table.ForeignKey(
                        name: "FK_Taluka_cityRegistrations_cityid",
                        column: x => x.cityid,
                        principalTable: "cityRegistrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffilatePackage_commissionid",
                table: "AffilatePackage",
                column: "commissionid");

            migrationBuilder.CreateIndex(
                name: "IX_AffilatePackage_membershipid",
                table: "AffilatePackage",
                column: "membershipid");

            migrationBuilder.CreateIndex(
                name: "IX_affiltateRegistrations_Membershipid",
                table: "affiltateRegistrations",
                column: "Membershipid");

            migrationBuilder.CreateIndex(
                name: "IX_affiltateRegistrations_cityid",
                table: "affiltateRegistrations",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Membershipid",
                table: "AspNetUsers",
                column: "Membershipid");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_cityid",
                table: "AspNetUsers",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOwnerRegi_cityid",
                table: "BusinessOwnerRegi",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessOwnerRegi_customerid",
                table: "BusinessOwnerRegi",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPackage_pkgId",
                table: "BusinessPackage",
                column: "pkgId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessRegistration_sectorid",
                table: "BusinessRegistration",
                column: "sectorid");

            migrationBuilder.CreateIndex(
                name: "IX_cityRegistrations_stateid",
                table: "cityRegistrations",
                column: "stateid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMaster_businessid",
                table: "ProductMaster",
                column: "businessid");

            migrationBuilder.CreateIndex(
                name: "IX_socials_customerid",
                table: "socials",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_StateRegistrations_countryid",
                table: "StateRegistrations",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_Taluka_cityid",
                table: "Taluka",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_videos_fkmoduleid",
                table: "videos",
                column: "fkmoduleid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertise");

            migrationBuilder.DropTable(
                name: "advertisementInfos");

            migrationBuilder.DropTable(
                name: "AffilatePackage");

            migrationBuilder.DropTable(
                name: "affiltateRegistrations");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankRegistration");

            migrationBuilder.DropTable(
                name: "BusinessOwnerRegi");

            migrationBuilder.DropTable(
                name: "BusinessPackage");

            migrationBuilder.DropTable(
                name: "businessratings");

            migrationBuilder.DropTable(
                name: "distance");

            migrationBuilder.DropTable(
                name: "emp");

            migrationBuilder.DropTable(
                name: "ProductMaster");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "sliders");

            migrationBuilder.DropTable(
                name: "socialdetails");

            migrationBuilder.DropTable(
                name: "socials");

            migrationBuilder.DropTable(
                name: "Taluka");

            migrationBuilder.DropTable(
                name: "tax");

            migrationBuilder.DropTable(
                name: "tblfeedback");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropTable(
                name: "commission");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PackageRegistration");

            migrationBuilder.DropTable(
                name: "BusinessRegistration");

            migrationBuilder.DropTable(
                name: "CustomerRegistration");

            migrationBuilder.DropTable(
                name: "moduleMasters");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "cityRegistrations");

            migrationBuilder.DropTable(
                name: "SectorRegistration");

            migrationBuilder.DropTable(
                name: "StateRegistrations");

            migrationBuilder.DropTable(
                name: "CountryRegistrations");
        }
    }
}
