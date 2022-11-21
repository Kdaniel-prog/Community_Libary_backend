using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Community_Libary.DAL.Migrations
{
    public partial class userreviewChange3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Reviews_ReviewId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_ReviewId",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "UserReviews");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "UserReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_ReviewId",
                table: "UserReviews",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Reviews_ReviewId",
                table: "UserReviews",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
