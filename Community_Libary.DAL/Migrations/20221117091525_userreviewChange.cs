using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Community_Libary.DAL.Migrations
{
    public partial class userreviewChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRecommend",
                table: "UserReviews");

            migrationBuilder.AddColumn<int>(
                name: "ReviewedId",
                table: "UserReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "dislike",
                table: "UserReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "like",
                table: "UserReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecommend",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserReviews_ReviewedId",
                table: "UserReviews",
                column: "ReviewedId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Users_ReviewedId",
                table: "UserReviews",
                column: "ReviewedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Users_ReviewedId",
                table: "UserReviews");

            migrationBuilder.DropIndex(
                name: "IX_UserReviews_ReviewedId",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "ReviewedId",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "dislike",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "like",
                table: "UserReviews");

            migrationBuilder.DropColumn(
                name: "IsRecommend",
                table: "Reviews");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecommend",
                table: "UserReviews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
