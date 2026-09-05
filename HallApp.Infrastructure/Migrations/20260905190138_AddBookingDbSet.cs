using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HallApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntity_HallEntities_HallId",
                table: "BookingEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntityServiceEntity_BookingEntity_BookingEntityId",
                table: "BookingEntityServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingEntity",
                table: "BookingEntity");

            migrationBuilder.RenameTable(
                name: "BookingEntity",
                newName: "BookingEntities");

            migrationBuilder.RenameIndex(
                name: "IX_BookingEntity_HallId",
                table: "BookingEntities",
                newName: "IX_BookingEntities_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingEntities",
                table: "BookingEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntities_HallEntities_HallId",
                table: "BookingEntities",
                column: "HallId",
                principalTable: "HallEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntityServiceEntity_BookingEntities_BookingEntityId",
                table: "BookingEntityServiceEntity",
                column: "BookingEntityId",
                principalTable: "BookingEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntities_HallEntities_HallId",
                table: "BookingEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingEntityServiceEntity_BookingEntities_BookingEntityId",
                table: "BookingEntityServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookingEntities",
                table: "BookingEntities");

            migrationBuilder.RenameTable(
                name: "BookingEntities",
                newName: "BookingEntity");

            migrationBuilder.RenameIndex(
                name: "IX_BookingEntities_HallId",
                table: "BookingEntity",
                newName: "IX_BookingEntity_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookingEntity",
                table: "BookingEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntity_HallEntities_HallId",
                table: "BookingEntity",
                column: "HallId",
                principalTable: "HallEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingEntityServiceEntity_BookingEntity_BookingEntityId",
                table: "BookingEntityServiceEntity",
                column: "BookingEntityId",
                principalTable: "BookingEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
