using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Community_Libary.DAL.Migrations
{
    public partial class tablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Users_UsersId",
                table: "BookReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Books_BookId",
                table: "Borrowed");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Users_UsersId",
                table: "Borrowed");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Users_reviewerId",
                table: "UserReviews");

            migrationBuilder.RenameColumn(
                name: "reviewerId",
                table: "UserReviews",
                newName: "ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_UserReviews_reviewerId",
                table: "UserReviews",
                newName: "IX_UserReviews_ReviewId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Borrowed",
                newName: "BorrowerId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrowed_UsersId",
                table: "Borrowed",
                newName: "IX_Borrowed_BorrowerId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "BookReviews",
                newName: "ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookReviews_UsersId",
                table: "BookReviews",
                newName: "IX_BookReviews_ReviewerId");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrowed",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookReviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewedId = table.Column<int>(type: "int", nullable: true),
                    ReviewerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewedId",
                        column: x => x.ReviewedId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Users_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewedId",
                table: "Reviews",
                column: "ReviewedId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewerId",
                table: "Reviews",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Books_BookId",
                table: "BookReviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Users_ReviewerId",
                table: "BookReviews",
                column: "ReviewerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_Books_BookId",
                table: "Borrowed",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_Users_BorrowerId",
                table: "Borrowed",
                column: "BorrowerId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Reviews_ReviewId",
                table: "UserReviews",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Books_BookId",
                table: "BookReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Users_ReviewerId",
                table: "BookReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Books_BookId",
                table: "Borrowed");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Users_BorrowerId",
                table: "Borrowed");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReviews_Reviews_ReviewId",
                table: "UserReviews");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReviews");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookReviews");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "UserReviews",
                newName: "reviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserReviews_ReviewId",
                table: "UserReviews",
                newName: "IX_UserReviews_reviewerId");

            migrationBuilder.RenameColumn(
                name: "BorrowerId",
                table: "Borrowed",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Borrowed_BorrowerId",
                table: "Borrowed",
                newName: "IX_Borrowed_UsersId");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "BookReviews",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_BookReviews_ReviewerId",
                table: "BookReviews",
                newName: "IX_BookReviews_UsersId");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrowed",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Users_UsersId",
                table: "BookReviews",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_Books_BookId",
                table: "Borrowed",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_Users_UsersId",
                table: "Borrowed",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReviews_Users_reviewerId",
                table: "UserReviews",
                column: "reviewerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
