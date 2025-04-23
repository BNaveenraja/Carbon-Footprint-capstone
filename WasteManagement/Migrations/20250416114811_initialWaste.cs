using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WasteManagement.Migrations
{
    /// <inheritdoc />
    public partial class initialWaste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WasteManagementEntities",
                columns: table => new
                {
                    WasteManagementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RecycledWaste = table.Column<double>(type: "float", nullable: false),
                    CompostWaste = table.Column<double>(type: "float", nullable: false),
                    LandfillWaste = table.Column<double>(type: "float", nullable: false),
                    RecordedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    WasteEmission = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteManagementEntities", x => x.WasteManagementId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WasteManagementEntities");
        }
    }
}
