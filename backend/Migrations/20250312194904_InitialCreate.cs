using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BowlingAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Bowler",
                columns: table => new
                {
                    BowlerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BowlerFirstName = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerMiddleInit = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerLastName = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerAddress = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerCity = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerState = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerZip = table.Column<string>(type: "TEXT", nullable: true),
                    BowlerPhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    TeamID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bowler", x => x.BowlerID);
                    table.ForeignKey(
                        name: "FK_Bowler_Team_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Team",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bowler_TeamID",
                table: "Bowler",
                column: "TeamID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bowler");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
