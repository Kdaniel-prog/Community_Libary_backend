using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Community_Libary.DAL.Migrations
{
    public partial class borrowedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Users_BookId",
                table: "Borrowed");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Borrowed",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrowed_UsersId",
                table: "Borrowed",
                column: "UsersId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Books_BookId",
                table: "Borrowed");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowed_Users_UsersId",
                table: "Borrowed");

            migrationBuilder.DropIndex(
                name: "IX_Borrowed_UsersId",
                table: "Borrowed");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Borrowed");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowed_Users_BookId",
                table: "Borrowed",
                column: "BookId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
