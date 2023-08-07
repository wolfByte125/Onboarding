using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogDemo.Migrations
{
    public partial class UserReferencedInNewReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NewReviews_UserId",
                table: "NewReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewReviews_Users_UserId",
                table: "NewReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewReviews_Users_UserId",
                table: "NewReviews");

            migrationBuilder.DropIndex(
                name: "IX_NewReviews_UserId",
                table: "NewReviews");
        }
    }
}
