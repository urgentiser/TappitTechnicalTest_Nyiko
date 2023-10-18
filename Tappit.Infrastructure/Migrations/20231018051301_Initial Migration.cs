using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tappit.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TappitTechnicalTest");

            migrationBuilder.CreateTable(
                name: "People",
                schema: "TappitTechnicalTest",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    IsAuthorised = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                schema: "TappitTechnicalTest",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteSports",
                schema: "TappitTechnicalTest",
                columns: table => new
                {
                    FavouriteSportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteSports", x => x.FavouriteSportId);
                    table.ForeignKey(
                        name: "FK_FavouriteSports_People_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "TappitTechnicalTest",
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteSports_Sports_SportId",
                        column: x => x.SportId,
                        principalSchema: "TappitTechnicalTest",
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteSports_PersonId",
                schema: "TappitTechnicalTest",
                table: "FavouriteSports",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteSports_SportId",
                schema: "TappitTechnicalTest",
                table: "FavouriteSports",
                column: "SportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteSports",
                schema: "TappitTechnicalTest");

            migrationBuilder.DropTable(
                name: "People",
                schema: "TappitTechnicalTest");

            migrationBuilder.DropTable(
                name: "Sports",
                schema: "TappitTechnicalTest");
        }
    }
}
