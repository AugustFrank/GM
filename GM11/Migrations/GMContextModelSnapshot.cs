using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GM11.Models;

namespace GM11.Migrations
{
    [DbContext(typeof(GMContext))]
    partial class GMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GM011.Models.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarTypeID");

                    b.Property<int>("CurrentMilage");

                    b.Property<int>("Doors");

                    b.Property<string>("Fuel");

                    b.Property<string>("FuelPerKM");

                    b.Property<int>("NextServiceMilage");

                    b.Property<string>("RegNo");

                    b.Property<int>("Seats");

                    b.Property<int>("ServiceID");

                    b.Property<string>("Transmission");

                    b.Property<DateTime>("Year");

                    b.HasKey("CarID");

                    b.HasIndex("CarTypeID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("GM011.Models.CarType", b =>
                {
                    b.Property<int>("CarTypeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("Type");

                    b.Property<decimal>("UnitPrice");

                    b.HasKey("CarTypeID");

                    b.ToTable("CarType");
                });

            modelBuilder.Entity("GM011.Models.Costumer", b =>
                {
                    b.Property<int>("CostumerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<DateTime?>("Age");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Discription");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<string>("MidName");

                    b.Property<int>("Phone");

                    b.Property<int>("YearsWithLicenns");

                    b.HasKey("CostumerID");

                    b.ToTable("Costumer");
                });

            modelBuilder.Entity("GM011.Models.Garage", b =>
                {
                    b.Property<int>("GarageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ContactName");

                    b.Property<string>("Discription");

                    b.Property<string>("GarageName");

                    b.Property<int>("Tlf");

                    b.HasKey("GarageID");

                    b.ToTable("Garage");
                });

            modelBuilder.Entity("GM011.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CarID");

                    b.Property<int?>("CostumerID");

                    b.Property<DateTime>("DateIN");

                    b.Property<DateTime>("DateOut");

                    b.Property<string>("Discription");

                    b.Property<int>("ExcessMileage");

                    b.Property<int>("MileageAllowance");

                    b.Property<int>("MileageIn");

                    b.Property<int>("MileageOut");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int?>("OrderStatus");

                    b.HasKey("OrderID");

                    b.HasIndex("CarID");

                    b.HasIndex("CostumerID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("GM011.Models.Part", b =>
                {
                    b.Property<int>("PartID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discription");

                    b.Property<int?>("PartCode");

                    b.Property<decimal?>("PartCost");

                    b.Property<string>("PartName");

                    b.HasKey("PartID");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("GM011.Models.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CarID");

                    b.Property<string>("Discription");

                    b.Property<int>("GarageID");

                    b.Property<int>("PartsID");

                    b.Property<decimal>("ServiceCost");

                    b.Property<DateTime>("ServiceDate");

                    b.Property<int>("ServiceMilage");

                    b.HasKey("ServiceID");

                    b.HasIndex("CarID");

                    b.HasIndex("GarageID");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("GM11.Models.Parts", b =>
                {
                    b.Property<int>("PartsID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PartID");

                    b.Property<int>("ServiceID");

                    b.HasKey("PartsID");

                    b.HasIndex("PartID");

                    b.HasIndex("ServiceID");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("GM011.Models.Car", b =>
                {
                    b.HasOne("GM011.Models.CarType", "CarType")
                        .WithMany("Cars")
                        .HasForeignKey("CarTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GM011.Models.Order", b =>
                {
                    b.HasOne("GM011.Models.Car", "Car")
                        .WithMany("Orders")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GM011.Models.Costumer", "Costumer")
                        .WithMany("Order")
                        .HasForeignKey("CostumerID");
                });

            modelBuilder.Entity("GM011.Models.Service", b =>
                {
                    b.HasOne("GM011.Models.Car", "Car")
                        .WithMany("Services")
                        .HasForeignKey("CarID");

                    b.HasOne("GM011.Models.Garage", "Garage")
                        .WithMany("Services")
                        .HasForeignKey("GarageID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GM11.Models.Parts", b =>
                {
                    b.HasOne("GM011.Models.Part", "Part")
                        .WithMany("Parts")
                        .HasForeignKey("PartID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GM011.Models.Service", "Service")
                        .WithMany("Parts")
                        .HasForeignKey("ServiceID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
