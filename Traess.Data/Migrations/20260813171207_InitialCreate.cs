using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Traess.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NationalId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LicenseNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LicenseCategories = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LicenseExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CapCertificateExpiryDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TractorUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LicensePlate = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    ChassisNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    EnginePowerHp = table.Column<int>(type: "integer", nullable: false),
                    FuelType = table.Column<int>(type: "integer", nullable: false),
                    GrossVehicleWeightKg = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    MaxTowableWeightKg = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    CouplingType = table.Column<int>(type: "integer", nullable: false),
                    HasSleepingCabin = table.Column<bool>(type: "boolean", nullable: false),
                    SleepingBerths = table.Column<int>(type: "integer", nullable: false),
                    CurrentOdometerKm = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    ItvExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InsuranceExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OwnershipType = table.Column<int>(type: "integer", nullable: false),
                    AcquisitionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TractorUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trailers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LicensePlate = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    ChassisNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TrailerType = table.Column<int>(type: "integer", nullable: false),
                    AxlesCount = table.Column<int>(type: "integer", nullable: false),
                    UnladenWeightKg = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    MaxPayloadWeightKg = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    GrossWeightKg = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    CouplingType = table.Column<int>(type: "integer", nullable: false),
                    CapacityVolumeM3 = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    ItvExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InsuranceExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    OwnershipType = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ClientName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RequestedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TransportOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TractorUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrailerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OriginAddress = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    DestinationAddress = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    ScheduledDepartureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ScheduledArrivalAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualDepartureAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualArrivalAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DistanceKm = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    CargoDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CargoWeightKg = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_TractorUnits_TractorUnitId",
                        column: x => x.TractorUnitId,
                        principalTable: "TractorUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Trailers_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_TransportOrders_TransportOrderId",
                        column: x => x.TransportOrderId,
                        principalTable: "TransportOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripDrivers",
                columns: table => new
                {
                    TripId = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsLead = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDrivers", x => new { x.TripId, x.DriverId });
                    table.ForeignKey(
                        name: "FK_TripDrivers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripDrivers_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LicenseNumber",
                table: "Drivers",
                column: "LicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_NationalId",
                table: "Drivers",
                column: "NationalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TractorUnits_LicensePlate",
                table: "TractorUnits",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trailers_LicensePlate",
                table: "Trailers",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransportOrders_OrderNumber",
                table: "TransportOrders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripDrivers_DriverId",
                table: "TripDrivers",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TractorUnitId",
                table: "Trips",
                column: "TractorUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TrailerId",
                table: "Trips",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TransportOrderId",
                table: "Trips",
                column: "TransportOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripDrivers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "TractorUnits");

            migrationBuilder.DropTable(
                name: "Trailers");

            migrationBuilder.DropTable(
                name: "TransportOrders");
        }
    }
}
