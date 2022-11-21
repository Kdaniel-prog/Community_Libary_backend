using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Community_Libary.DAL.Migrations
{
    public partial class userreviewChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Users_ReviewedId",
                table: "UserReviews");

            migrationBuilder.RenameColumn(
                name: "like",
                table: "UserReviews",
                newName: "Like");

            migrationBuilder.RenameColumn(
                name: "dislike",
                table: "UserReviews",
                newName: "Dislike");

            migrationBuilder.RenameColumn(
                name: "ReviewedId",
                table: "UserReviews",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserReviews_ReviewedId",
                table: "UserReviews",
                newName: "IX_UserReviews_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Users_UserID",
                table: "UserReviews",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Users_UserID",
                table: "UserReviews");

            migrationBuilder.RenameColumn(
                name: "Like",
                table: "UserReviews",
                newName: "like");

            migrationBuilder.RenameColumn(
                name: "Dislike",
                table: "UserReviews",
                newName: "dislike");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserReviews",
                newName: "ReviewedId");

            migrationBuilder.RenameIndex(
                name: "IX_UserReviews_UserID",
                table: "UserReviews",
                newName: "IX_UserReviews_ReviewedId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Users_ReviewedId",
                table: "UserReviews",
                column: "ReviewedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
