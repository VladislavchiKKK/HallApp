using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HallApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HallEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    PricePerHour = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HallEntityServiceEntity",
                columns: table => new
                {
                    HallEntitiesId = table.Column<int>(type: "int", nullable: false),
                    ServiceEntitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallEntityServiceEntity", x => new { x.HallEntitiesId, x.ServiceEntitiesId });
                    table.ForeignKey(
                        name: "FK_HallEntityServiceEntity_HallEntities_HallEntitiesId",
                        column: x => x.HallEntitiesId,
                        principalTable: "HallEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HallEntityServiceEntity_ServiceEntities_ServiceEntitiesId",
                        column: x => x.ServiceEntitiesId,
                        principalTable: "ServiceEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HallEntities",
                columns: new[] { "Id", "Capacity", "Name", "PricePerHour" },
                values: new object[,]
                {
                    { 1, 50, "Hall A", 2000m },
                    { 2, 100, "Hall B", 3500m },
                    { 3, 30, "Hall C", 1500m }
                });

            migrationBuilder.InsertData(
                table: "ServiceEntities",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Projector", 500m },
                    { 2, "Wi-Fi", 300m },
                    { 3, "Sound", 700m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HallEntityServiceEntity_ServiceEntitiesId",
                table: "HallEntityServiceEntity",
                column: "ServiceEntitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallEntityServiceEntity");

            migrationBuilder.DropTable(
                name: "HallEntities");

            migrationBuilder.DropTable(
                name: "ServiceEntities");
        }
    }
}
