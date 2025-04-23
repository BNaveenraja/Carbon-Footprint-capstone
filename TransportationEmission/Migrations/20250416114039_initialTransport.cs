using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportationEmission.Migrations
{
    /// <inheritdoc />
    public partial class initialTransport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transportationEntities",
                columns: table => new
                {
                    TransportationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetrolUsage = table.Column<double>(type: "float", nullable: false),
                    DieselUsage = table.Column<double>(type: "float", nullable: false),
                    CNGUsage = table.Column<double>(type: "float", nullable: false),
                    RecordedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransportEmission = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportationEntities", x => x.TransportationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transportationEntities");
        }
    }
}
