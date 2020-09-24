using Microsoft.EntityFrameworkCore.Migrations;

namespace ZirveChallenge.Data.Migrations
{
    public partial class MovieRatingupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieRatings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieRatings");
        }
    }
}
