using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_user_role_role_id",
                table: "user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_feature_feature_id",
                table: "role_feature",
                column: "feature_id");

            migrationBuilder.CreateIndex(
                name: "ix_refresh_token_user_id",
                table: "refresh_token",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_refresh_token_user_user_id",
                table: "refresh_token",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_role_feature_feature_feature_id",
                table: "role_feature",
                column: "feature_id",
                principalTable: "feature",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_role_feature_role_role_id",
                table: "role_feature",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_user_role_role_role_id",
                table: "user_role",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_user_role_user_user_id",
                table: "user_role",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_refresh_token_user_user_id",
                table: "refresh_token");

            migrationBuilder.DropForeignKey(
                name: "fk_role_feature_feature_feature_id",
                table: "role_feature");

            migrationBuilder.DropForeignKey(
                name: "fk_role_feature_role_role_id",
                table: "role_feature");

            migrationBuilder.DropForeignKey(
                name: "fk_user_role_role_role_id",
                table: "user_role");

            migrationBuilder.DropForeignKey(
                name: "fk_user_role_user_user_id",
                table: "user_role");

            migrationBuilder.DropIndex(
                name: "ix_user_role_role_id",
                table: "user_role");

            migrationBuilder.DropIndex(
                name: "ix_role_feature_feature_id",
                table: "role_feature");

            migrationBuilder.DropIndex(
                name: "ix_refresh_token_user_id",
                table: "refresh_token");
        }
    }
}
