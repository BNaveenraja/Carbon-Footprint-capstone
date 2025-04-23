using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseHoldEmission.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseHoldEntities",
                columns: table => new
                {
                    HouseHoldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ElectricityUsage = table.Column<double>(type: "float", nullable: false),
                    LPGUsage = table.Column<double>(type: "float", nullable: false),
                    CoalUsage = table.Column<double>(type: "float", nullable: false),
                    RecordedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HouseHoldEmission = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseHoldEntities", x => x.HouseHoldId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseHoldEntities");
        }
    }
}
