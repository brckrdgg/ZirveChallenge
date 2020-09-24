using Microsoft.EntityFrameworkCore.Migrations;

namespace ZirveChallenge.Data.Migrations
{
    public partial class Movie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adult = table.Column<bool>(nullable: false),
                    BackdropPath = table.Column<string>(nullable: true),
                    Budget = table.Column<long>(nullable: false),
                    ImdbId = table.Column<string>(nullable: true),
                    OriginalLanguage = table.Column<string>(nullable: true),
                    OriginalTitle = table.Column<string>(nullable: true),
                    Overview = table.Column<string>(nullable: true),
                    Popularity = table.Column<double>(nullable: false),
                    PosterPath = table.Column<string>(nullable: true),
                    Revenue = table.Column<long>(nullable: false),
                    Runtime = table.Column<long>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Tagline = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Video = table.Column<bool>(nullable: false),
                    VoteAverage = table.Column<double>(nullable: false),
                    VoteCount = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
