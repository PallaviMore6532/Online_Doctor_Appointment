using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Db_Created : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminTbl",
                columns: table => new
                {
                    AdminID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTbl", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "CountryTbl",
                columns: table => new
                {
                    CountryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTbl", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTbl",
                columns: table => new
                {
                    MedicineID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MfgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MfgDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTbl", x => x.MedicineID);
                });

            migrationBuilder.CreateTable(
                name: "SpecilityTbl",
                columns: table => new
                {
                    SpecilityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecilityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecilityTbl", x => x.SpecilityID);
                });

            migrationBuilder.CreateTable(
                name: "StateTbl",
                columns: table => new
                {
                    StateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTbl", x => x.StateID);
                    table.ForeignKey(
                        name: "FK_StateTbl_CountryTbl_CountryID",
                        column: x => x.CountryID,
                        principalTable: "CountryTbl",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTbl",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTbl", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_UserTbl_CountryTbl_CountryID",
                        column: x => x.CountryID,
                        principalTable: "CountryTbl",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CityTbl",
                columns: table => new
                {
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTbl", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_CityTbl_StateTbl_StateID",
                        column: x => x.StateID,
                        principalTable: "StateTbl",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientTbl",
                columns: table => new
                {
                    PatientID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTbl", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_PatientTbl_UserTbl_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreaTbl",
                columns: table => new
                {
                    AreaID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTbl", x => x.AreaID);
                    table.ForeignKey(
                        name: "FK_AreaTbl_CityTbl_CityID",
                        column: x => x.CityID,
                        principalTable: "CityTbl",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicTbl",
                columns: table => new
                {
                    ClinicID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LandLineNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logopath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicTbl", x => x.ClinicID);
                    table.ForeignKey(
                        name: "FK_ClinicTbl_CityTbl_CityID",
                        column: x => x.CityID,
                        principalTable: "CityTbl",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicAdminTbl",
                columns: table => new
                {
                    ClinicAdminID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicAdminTbl", x => x.ClinicAdminID);
                    table.ForeignKey(
                        name: "FK_ClinicAdminTbl_ClinicTbl_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "ClinicTbl",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicCertificateTbl",
                columns: table => new
                {
                    ClinicCertificateID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicID = table.Column<long>(type: "bigint", nullable: false),
                    CertificateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicCertificateTbl", x => x.ClinicCertificateID);
                    table.ForeignKey(
                        name: "FK_ClinicCertificateTbl_ClinicTbl_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "ClinicTbl",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicFacilityTbl",
                columns: table => new
                {
                    ClinicFacilityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicFacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicFacilityTbl", x => x.ClinicFacilityID);
                    table.ForeignKey(
                        name: "FK_ClinicFacilityTbl_ClinicTbl_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "ClinicTbl",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicRatingTbl",
                columns: table => new
                {
                    ClinicRatingID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    ClinicID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicRatingTbl", x => x.ClinicRatingID);
                    table.ForeignKey(
                        name: "FK_ClinicRatingTbl_ClinicTbl_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "ClinicTbl",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicRatingTbl_UserTbl_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorTbl",
                columns: table => new
                {
                    DoctorID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorExperiance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorQualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaID = table.Column<long>(type: "bigint", nullable: false),
                    ClinicID = table.Column<long>(type: "bigint", nullable: false),
                    VisitingCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTbl", x => x.DoctorID);
                    table.ForeignKey(
                        name: "FK_DoctorTbl_AreaTbl_AreaID",
                        column: x => x.AreaID,
                        principalTable: "AreaTbl",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorTbl_ClinicTbl_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "ClinicTbl",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OPDSessionTbl",
                columns: table => new
                {
                    OPDSessionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPDSessionTbl", x => x.OPDSessionID);
                    table.ForeignKey(
                        name: "FK_OPDSessionTbl_ClinicTbl_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "ClinicTbl",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorRatingTbl",
                columns: table => new
                {
                    DoctorRatingID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    DoctorID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorRatingTbl", x => x.DoctorRatingID);
                    table.ForeignKey(
                        name: "FK_DoctorRatingTbl_DoctorTbl_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorTbl",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorRatingTbl_UserTbl_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecialityTbl",
                columns: table => new
                {
                    DoctorSpecialityID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<long>(type: "bigint", nullable: false),
                    SpecilityID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialityTbl", x => x.DoctorSpecialityID);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialityTbl_DoctorTbl_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorTbl",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialityTbl_SpecilityTbl_SpecilityID",
                        column: x => x.SpecilityID,
                        principalTable: "SpecilityTbl",
                        principalColumn: "SpecilityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DcotorScheduleTbl",
                columns: table => new
                {
                    DoctorScheduleID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<long>(type: "bigint", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interval = table.Column<long>(type: "bigint", nullable: false),
                    DoctorID = table.Column<long>(type: "bigint", nullable: false),
                    OPDSessionID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcotorScheduleTbl", x => x.DoctorScheduleID);
                    table.ForeignKey(
                        name: "FK_DcotorScheduleTbl_DoctorTbl_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorTbl",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DcotorScheduleTbl_OPDSessionTbl_OPDSessionID",
                        column: x => x.OPDSessionID,
                        principalTable: "OPDSessionTbl",
                        principalColumn: "OPDSessionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoctorClinicSessionTbl",
                columns: table => new
                {
                    DoctorClinicSessionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeInterval = table.Column<int>(type: "int", nullable: false),
                    DoctorID = table.Column<long>(type: "bigint", nullable: false),
                    ClinicID = table.Column<long>(type: "bigint", nullable: false),
                    OPDSessionID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorClinicSessionTbl", x => x.DoctorClinicSessionID);
                    table.ForeignKey(
                        name: "FK_DoctorClinicSessionTbl_ClinicTbl_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "ClinicTbl",
                        principalColumn: "ClinicID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorClinicSessionTbl_DoctorTbl_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorTbl",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorClinicSessionTbl_OPDSessionTbl_OPDSessionID",
                        column: x => x.OPDSessionID,
                        principalTable: "OPDSessionTbl",
                        principalColumn: "OPDSessionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookedAppointmentTbl",
                columns: table => new
                {
                    BookedAppointmentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PatientID = table.Column<long>(type: "bigint", nullable: false),
                    DoctorScheduleID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedAppointmentTbl", x => x.BookedAppointmentID);
                    table.ForeignKey(
                        name: "FK_BookedAppointmentTbl_DcotorScheduleTbl_DoctorScheduleID",
                        column: x => x.DoctorScheduleID,
                        principalTable: "DcotorScheduleTbl",
                        principalColumn: "DoctorScheduleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookedAppointmentTbl_PatientTbl_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientTbl",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookedAppPaymentTbl",
                columns: table => new
                {
                    BookedAppointmentPaymentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMode = table.Column<int>(type: "int", nullable: false),
                    BookedAppointmentID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedAppPaymentTbl", x => x.BookedAppointmentPaymentID);
                    table.ForeignKey(
                        name: "FK_BookedAppPaymentTbl_BookedAppointmentTbl_BookedAppointmentID",
                        column: x => x.BookedAppointmentID,
                        principalTable: "BookedAppointmentTbl",
                        principalColumn: "BookedAppointmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionTbl",
                columns: table => new
                {
                    PrescriptionID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookedAppointmentID = table.Column<long>(type: "bigint", nullable: false),
                    DoctorID = table.Column<long>(type: "bigint", nullable: false),
                    PatientID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionTbl", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_PrescriptionTbl_BookedAppointmentTbl_BookedAppointmentID",
                        column: x => x.BookedAppointmentID,
                        principalTable: "BookedAppointmentTbl",
                        principalColumn: "BookedAppointmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionTbl_DoctorTbl_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "DoctorTbl",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionTbl_PatientTbl_PatientID",
                        column: x => x.PatientID,
                        principalTable: "PatientTbl",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionDetailTbl",
                columns: table => new
                {
                    PrescriptionDetailID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<long>(type: "bigint", nullable: false),
                    Dosage = table.Column<long>(type: "bigint", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrescriptionID = table.Column<long>(type: "bigint", nullable: false),
                    MedicineID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDetailTbl", x => x.PrescriptionDetailID);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetailTbl_MedicineTbl_MedicineID",
                        column: x => x.MedicineID,
                        principalTable: "MedicineTbl",
                        principalColumn: "MedicineID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrescriptionDetailTbl_PrescriptionTbl_PrescriptionID",
                        column: x => x.PrescriptionID,
                        principalTable: "PrescriptionTbl",
                        principalColumn: "PrescriptionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaTbl_CityID",
                table: "AreaTbl",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_BookedAppointmentTbl_DoctorScheduleID",
                table: "BookedAppointmentTbl",
                column: "DoctorScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_BookedAppointmentTbl_PatientID",
                table: "BookedAppointmentTbl",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_BookedAppPaymentTbl_BookedAppointmentID",
                table: "BookedAppPaymentTbl",
                column: "BookedAppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CityTbl_StateID",
                table: "CityTbl",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicAdminTbl_ClinicID",
                table: "ClinicAdminTbl",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicCertificateTbl_ClinicID",
                table: "ClinicCertificateTbl",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicFacilityTbl_ClinicID",
                table: "ClinicFacilityTbl",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicRatingTbl_ClinicID",
                table: "ClinicRatingTbl",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicRatingTbl_UserID",
                table: "ClinicRatingTbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicTbl_CityID",
                table: "ClinicTbl",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_DcotorScheduleTbl_DoctorID",
                table: "DcotorScheduleTbl",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DcotorScheduleTbl_OPDSessionID",
                table: "DcotorScheduleTbl",
                column: "OPDSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinicSessionTbl_ClinicID",
                table: "DoctorClinicSessionTbl",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinicSessionTbl_DoctorID",
                table: "DoctorClinicSessionTbl",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinicSessionTbl_OPDSessionID",
                table: "DoctorClinicSessionTbl",
                column: "OPDSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorRatingTbl_DoctorID",
                table: "DoctorRatingTbl",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorRatingTbl_UserID",
                table: "DoctorRatingTbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialityTbl_DoctorID",
                table: "DoctorSpecialityTbl",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialityTbl_SpecilityID",
                table: "DoctorSpecialityTbl",
                column: "SpecilityID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTbl_AreaID",
                table: "DoctorTbl",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTbl_ClinicID",
                table: "DoctorTbl",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_OPDSessionTbl_ClinicID",
                table: "OPDSessionTbl",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTbl_UserID",
                table: "PatientTbl",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetailTbl_MedicineID",
                table: "PrescriptionDetailTbl",
                column: "MedicineID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionDetailTbl_PrescriptionID",
                table: "PrescriptionDetailTbl",
                column: "PrescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionTbl_BookedAppointmentID",
                table: "PrescriptionTbl",
                column: "BookedAppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionTbl_DoctorID",
                table: "PrescriptionTbl",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_PrescriptionTbl_PatientID",
                table: "PrescriptionTbl",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_StateTbl_CountryID",
                table: "StateTbl",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTbl_CountryID",
                table: "UserTbl",
                column: "CountryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTbl");

            migrationBuilder.DropTable(
                name: "BookedAppPaymentTbl");

            migrationBuilder.DropTable(
                name: "ClinicAdminTbl");

            migrationBuilder.DropTable(
                name: "ClinicCertificateTbl");

            migrationBuilder.DropTable(
                name: "ClinicFacilityTbl");

            migrationBuilder.DropTable(
                name: "ClinicRatingTbl");

            migrationBuilder.DropTable(
                name: "DoctorClinicSessionTbl");

            migrationBuilder.DropTable(
                name: "DoctorRatingTbl");

            migrationBuilder.DropTable(
                name: "DoctorSpecialityTbl");

            migrationBuilder.DropTable(
                name: "PrescriptionDetailTbl");

            migrationBuilder.DropTable(
                name: "SpecilityTbl");

            migrationBuilder.DropTable(
                name: "MedicineTbl");

            migrationBuilder.DropTable(
                name: "PrescriptionTbl");

            migrationBuilder.DropTable(
                name: "BookedAppointmentTbl");

            migrationBuilder.DropTable(
                name: "DcotorScheduleTbl");

            migrationBuilder.DropTable(
                name: "PatientTbl");

            migrationBuilder.DropTable(
                name: "DoctorTbl");

            migrationBuilder.DropTable(
                name: "OPDSessionTbl");

            migrationBuilder.DropTable(
                name: "UserTbl");

            migrationBuilder.DropTable(
                name: "AreaTbl");

            migrationBuilder.DropTable(
                name: "ClinicTbl");

            migrationBuilder.DropTable(
                name: "CityTbl");

            migrationBuilder.DropTable(
                name: "StateTbl");

            migrationBuilder.DropTable(
                name: "CountryTbl");
        }
    }
}
