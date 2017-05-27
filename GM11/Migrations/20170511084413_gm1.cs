using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GM11.Migrations
{
    public partial class gm1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    CarTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.CarTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Costumer",
                columns: table => new
                {
                    CostumerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    Age = table.Column<DateTime>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MidName = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    YearsWithLicenns = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumer", x => x.CostumerID);
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    GarageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    GarageName = table.Column<string>(nullable: true),
                    Tlf = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.GarageID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarTypeID = table.Column<int>(nullable: false),
                    CurrentMilage = table.Column<int>(nullable: false),
                    Doors = table.Column<int>(nullable: false),
                    Fuel = table.Column<string>(nullable: true),
                    FuelPerKM = table.Column<string>(nullable: true),
                    NextServiceMilage = table.Column<int>(nullable: false),
                    RegNo = table.Column<string>(nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    ServiceID = table.Column<int>(nullable: false),
                    Transmission = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Car_CarType_CarTypeID",
                        column: x => x.CarTypeID,
                        principalTable: "CarType",
                        principalColumn: "CarTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarID = table.Column<int>(nullable: false),
                    CostumerID = table.Column<int>(nullable: true),
                    DateIN = table.Column<DateTime>(nullable: false),
                    DateOut = table.Column<DateTime>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    ExcessMileage = table.Column<int>(nullable: false),
                    MileageAllowance = table.Column<int>(nullable: false),
                    MileageIn = table.Column<int>(nullable: false),
                    MileageOut = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Car_CarID",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Costumer_CostumerID",
                        column: x => x.CostumerID,
                        principalTable: "Costumer",
                        principalColumn: "CostumerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarID = table.Column<int>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    GarageID = table.Column<int>(nullable: false),
                    PartID = table.Column<int>(nullable: false),
                    ServiceCost = table.Column<decimal>(nullable: false),
                    ServiceDate = table.Column<DateTime>(nullable: false),
                    ServiceMilage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_Service_Car_CarID",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Garage_GarageID",
                        column: x => x.GarageID,
                        principalTable: "Garage",
                        principalColumn: "GarageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    PartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discription = table.Column<string>(nullable: true),
                    PartCode = table.Column<int>(nullable: true),
                    PartCost = table.Column<decimal>(nullable: true),
                    PartName = table.Column<string>(nullable: true),
                    ServiceID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.PartID);
                    table.ForeignKey(
                        name: "FK_Part_Service_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "Service",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarTypeID",
                table: "Car",
                column: "CarTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CarID",
                table: "Order",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CostumerID",
                table: "Order",
                column: "CostumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Part_ServiceID",
                table: "Part",
                column: "ServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CarID",
                table: "Service",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Service_GarageID",
                table: "Service",
                column: "GarageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Costumer");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "CarType");
        }
    }
}
