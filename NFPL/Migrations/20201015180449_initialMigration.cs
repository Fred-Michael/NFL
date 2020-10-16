using Microsoft.EntityFrameworkCore.Migrations;

namespace NFPL.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ConferenceID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ConferenceID);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DivisionID = table.Column<string>(nullable: true),
                    ConferenceID = table.Column<string>(nullable: true),
                    TeamLogo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Conferences_ConferenceID",
                        column: x => x.ConferenceID,
                        principalTable: "Conferences",
                        principalColumn: "ConferenceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_DivisionID",
                        column: x => x.DivisionID,
                        principalTable: "Divisions",
                        principalColumn: "DivisionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Conferences",
                columns: new[] { "ConferenceID", "Name" },
                values: new object[,]
                {
                    { "afc", "AFC" },
                    { "nfc", "NFC" }
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "DivisionID", "Name" },
                values: new object[,]
                {
                    { "north", "North" },
                    { "south", "South" },
                    { "east", "East" },
                    { "west", "West" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "ConferenceID", "DivisionID", "Name", "TeamLogo" },
                values: new object[,]
                {
                    { "bal", "afc", "north", "Baltimore Ravens", "BAL.png" },
                    { "oak", "afc", "west", "Oakland Raiders", "OAK.png" },
                    { "lar", "nfc", "west", "Los Angeles Rams", "LAR.png" },
                    { "lac", "afc", "west", "Los Angeles Chargers", "LAC.png" },
                    { "kc", "afc", "west", "Kansas City Chiefs", "KC.png" },
                    { "den", "afc", "west", "Denver Broncos", "DEN.png" },
                    { "ari", "nfc", "west", "Arizona Cardinals", "ARI.png" },
                    { "was", "nfc", "east", "Washington Redskins", "WAS.png" },
                    { "phi", "nfc", "east", "Philadelphia Eagles", "PHI.png" },
                    { "nyj", "afc", "east", "New York Jets", "NYJ.png" },
                    { "nyg", "nfc", "east", "New York Giants", "NYG.png" },
                    { "ne", "afc", "east", "New England Patriots", "NE.png" },
                    { "mia", "afc", "east", "Miami Dolphins", "MIA.png" },
                    { "dal", "nfc", "east", "Dallas Cowboys", "DAL.png" },
                    { "buf", "afc", "east", "Buffalo Bills", "BUF.png" },
                    { "ten", "afc", "south", "Tennessee Titans", "TEN.png" },
                    { "tb", "nfc", "south", "Tampa Bay Buccaneers", "TB.png" },
                    { "no", "nfc", "south", "New Orleans Saints", "NO.png" },
                    { "jax", "afc", "south", "Jacksonville Jaguars", "JAX.png" },
                    { "ind", "afc", "south", "Indianapolis Colts", "IND.png" },
                    { "hou", "afc", "south", "Houston Texans", "HOU.png" },
                    { "car", "nfc", "south", "Carolina Panthers", "CAR.png" },
                    { "atl", "nfc", "south", "Atlanta Falcons", "ATL.png" },
                    { "pit", "afc", "north", "Pittsburgh Steelers", "PIT.png" },
                    { "min", "nfc", "north", "Minnesota Vikings", "MIN.png" },
                    { "gb", "nfc", "north", "Green Bay Packers", "GB.png" },
                    { "det", "nfc", "north", "Detroit Lions", "DET.png" },
                    { "cle", "afc", "north", "Cleveland Browns", "CLE.png" },
                    { "cin", "afc", "north", "Cincinnati Bengals", "CIN.png" },
                    { "chi", "nfc", "north", "Chicago Bears", "CHI.png" },
                    { "sea", "nfc", "west", "Seattle Seahawks", "SEA.png" },
                    { "sf", "nfc", "west", "San Francisco 49ers", "SF.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ConferenceID",
                table: "Teams",
                column: "ConferenceID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DivisionID",
                table: "Teams",
                column: "DivisionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Divisions");
        }
    }
}
