using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TournamentsWebApplication.Data.Migrations
{
    public partial class TournamentInintial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventDetailStatus",
                columns: table => new
                {
                    EventDetailStatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDetailStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetailStatus", x => x.EventDetailStatusID);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    TournamentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.TournamentID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TournamentID = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    EventNumber = table.Column<int>(nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: true),
                    EventEndDateTime = table.Column<DateTime>(nullable: true),
                    AutoClose = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Event_Tournament_TournamentID",
                        column: x => x.TournamentID,
                        principalTable: "Tournament",
                        principalColumn: "TournamentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDetail",
                columns: table => new
                {
                    EventDetailID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(nullable: false),
                    EventDetailStatusID = table.Column<int>(nullable: false),
                    EventDetailName = table.Column<string>(nullable: true),
                    EventDetailNumber = table.Column<int>(nullable: false),
                    EventDetailOdd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinishingPosition = table.Column<int>(nullable: false),
                    FirstTimer = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetail", x => x.EventDetailID);
                    table.ForeignKey(
                        name: "FK_EventDetail_EventDetailStatus_EventDetailStatusID",
                        column: x => x.EventDetailStatusID,
                        principalTable: "EventDetailStatus",
                        principalColumn: "EventDetailStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDetail_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_TournamentID",
                table: "Event",
                column: "TournamentID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetail_EventDetailStatusID",
                table: "EventDetail",
                column: "EventDetailStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetail_EventID",
                table: "EventDetail",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDetail");

            migrationBuilder.DropTable(
                name: "EventDetailStatus");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Tournament");
        }
    }
}
