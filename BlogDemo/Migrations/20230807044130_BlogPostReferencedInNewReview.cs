using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogDemo.Migrations
{
    public partial class BlogPostReferencedInNewReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "NewReviews",
                newName: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_NewReviews_BlogPostId",
                table: "NewReviews",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewReviews_BlogPosts_BlogPostId",
                table: "NewReviews",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewReviews_BlogPosts_BlogPostId",
                table: "NewReviews");

            migrationBuilder.DropIndex(
                name: "IX_NewReviews_BlogPostId",
                table: "NewReviews");

            migrationBuilder.RenameColumn(
                name: "BlogPostId",
                table: "NewReviews",
                newName: "BlogId");
        }
    }
}
