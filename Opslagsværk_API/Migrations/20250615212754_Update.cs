using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opslagsværk_API.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentCategories_Assignments_Assignment_ID",
                table: "AssignmentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentCategories_Categories_Category_ID",
                table: "AssignmentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_User_ID",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "Assignments",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Img_URL",
                table: "Assignments",
                newName: "ImgURL");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_User_ID",
                table: "Assignments",
                newName: "IX_Assignments_UserID");

            migrationBuilder.RenameColumn(
                name: "Category_ID",
                table: "AssignmentCategories",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "Assignment_ID",
                table: "AssignmentCategories",
                newName: "AssignmentID");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentCategories_Category_ID",
                table: "AssignmentCategories",
                newName: "IX_AssignmentCategories_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentCategories_Assignment_ID",
                table: "AssignmentCategories",
                newName: "IX_AssignmentCategories_AssignmentID");

            migrationBuilder.AlterColumn<string>(
                name: "Hashed_password",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentCategories_Assignments_AssignmentID",
                table: "AssignmentCategories",
                column: "AssignmentID",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentCategories_Categories_CategoryID",
                table: "AssignmentCategories",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_UserID",
                table: "Assignments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentCategories_Assignments_AssignmentID",
                table: "AssignmentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentCategories_Categories_CategoryID",
                table: "AssignmentCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Users_UserID",
                table: "Assignments");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Assignments",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "ImgURL",
                table: "Assignments",
                newName: "Img_URL");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_UserID",
                table: "Assignments",
                newName: "IX_Assignments_User_ID");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "AssignmentCategories",
                newName: "Category_ID");

            migrationBuilder.RenameColumn(
                name: "AssignmentID",
                table: "AssignmentCategories",
                newName: "Assignment_ID");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentCategories_CategoryID",
                table: "AssignmentCategories",
                newName: "IX_AssignmentCategories_Category_ID");

            migrationBuilder.RenameIndex(
                name: "IX_AssignmentCategories_AssignmentID",
                table: "AssignmentCategories",
                newName: "IX_AssignmentCategories_Assignment_ID");

            migrationBuilder.AlterColumn<string>(
                name: "Hashed_password",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentCategories_Assignments_Assignment_ID",
                table: "AssignmentCategories",
                column: "Assignment_ID",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentCategories_Categories_Category_ID",
                table: "AssignmentCategories",
                column: "Category_ID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Users_User_ID",
                table: "Assignments",
                column: "User_ID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
