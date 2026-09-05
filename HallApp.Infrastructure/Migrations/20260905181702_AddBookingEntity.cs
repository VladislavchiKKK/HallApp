using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingEntity_HallEntities_HallId",
                        column: x => x.HallId,
                        principalTable: "HallEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingEntityServiceEntity",
                columns: table => new
                {
                    BookingEntityId = table.Column<int>(type: "int", nullable: false),
                    ServiceEntitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEntityServiceEntity", x => new { x.BookingEntityId, x.ServiceEntitiesId });
                    table.ForeignKey(
                        name: "FK_BookingEntityServiceEntity_BookingEntity_BookingEntityId",
                        column: x => x.BookingEntityId,
                        principalTable: "BookingEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingEntityServiceEntity_ServiceEntities_ServiceEntitiesId",
                        column: x => x.ServiceEntitiesId,
                        principalTable: "ServiceEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntity_HallId",
                table: "BookingEntity",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntityServiceEntity_ServiceEntitiesId",
                table: "BookingEntityServiceEntity",
                column: "ServiceEntitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingEntityServiceEntity");

            migrationBuilder.DropTable(
                name: "BookingEntity");
        }
    }
}
