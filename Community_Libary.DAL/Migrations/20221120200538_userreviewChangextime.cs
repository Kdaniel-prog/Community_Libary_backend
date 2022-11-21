using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Community_Libary.DAL.Migrations
{
    public partial class userreviewChangextime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_UserReviews_UserReviewsId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserReviewsId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UserReviewsId",
                table: "Reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserReviewsId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserReviewsId",
                table: "Reviews",
                column: "UserReviewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_UserReviews_UserReviewsId",
                table: "Reviews",
                column: "UserReviewsId",
                principalTable: "UserReviews",
                principalColumn: "Id");
        }
    }
}
