using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.Data.Migrations
{
    public partial class UpdateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Update_time",
                table: "user_tab",
                newName: "update_time");

            migrationBuilder.RenameIndex(
                name: "IX_user_tab_Update_time",
                table: "user_tab",
                newName: "IX_user_tab_update_time");

            migrationBuilder.RenameColumn(
                name: "Update_time",
                table: "user_role_tab",
                newName: "update_time");

            migrationBuilder.RenameIndex(
                name: "IX_user_role_tab_Update_time",
                table: "user_role_tab",
                newName: "IX_user_role_tab_update_time");

            migrationBuilder.RenameColumn(
                name: "Update_time",
                table: "comment_tab",
                newName: "update_time");

            migrationBuilder.RenameIndex(
                name: "IX_comment_tab_Update_time",
                table: "comment_tab",
                newName: "IX_comment_tab_update_time");

            migrationBuilder.RenameColumn(
                name: "Update_time",
                table: "category_tab",
                newName: "update_time");

            migrationBuilder.RenameIndex(
                name: "IX_category_tab_Update_time",
                table: "category_tab",
                newName: "IX_category_tab_update_time");

            migrationBuilder.RenameColumn(
                name: "Update_time",
                table: "article_tab",
                newName: "update_time");

            migrationBuilder.RenameIndex(
                name: "IX_article_tab_Update_time",
                table: "article_tab",
                newName: "IX_article_tab_update_time");

            migrationBuilder.AlterColumn<Guid>(
                name: "username",
                table: "user_tab",
                type: "char(128)",
                maxLength: 128,
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "char(128)",
                oldMaxLength: 128)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "user_tab",
                newName: "Update_time");

            migrationBuilder.RenameIndex(
                name: "IX_user_tab_update_time",
                table: "user_tab",
                newName: "IX_user_tab_Update_time");

            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "user_role_tab",
                newName: "Update_time");

            migrationBuilder.RenameIndex(
                name: "IX_user_role_tab_update_time",
                table: "user_role_tab",
                newName: "IX_user_role_tab_Update_time");

            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "comment_tab",
                newName: "Update_time");

            migrationBuilder.RenameIndex(
                name: "IX_comment_tab_update_time",
                table: "comment_tab",
                newName: "IX_comment_tab_Update_time");

            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "category_tab",
                newName: "Update_time");

            migrationBuilder.RenameIndex(
                name: "IX_category_tab_update_time",
                table: "category_tab",
                newName: "IX_category_tab_Update_time");

            migrationBuilder.RenameColumn(
                name: "update_time",
                table: "article_tab",
                newName: "Update_time");

            migrationBuilder.RenameIndex(
                name: "IX_article_tab_update_time",
                table: "article_tab",
                newName: "IX_article_tab_Update_time");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "user_tab",
                type: "char(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(128)",
                oldMaxLength: 128)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");
        }
    }
}
