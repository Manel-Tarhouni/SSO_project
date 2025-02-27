using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thirdM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RolesRoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UsersUserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "User_Roles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UsersUserId",
                table: "User_Roles",
                newName: "IX_User_Roles_UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Roles",
                table: "User_Roles",
                columns: new[] { "RolesRoleId", "UsersUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_Roles_RolesRoleId",
                table: "User_Roles",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Roles_Users_UsersUserId",
                table: "User_Roles",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_Roles_RolesRoleId",
                table: "User_Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Roles_Users_UsersUserId",
                table: "User_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Roles",
                table: "User_Roles");

            migrationBuilder.RenameTable(
                name: "User_Roles",
                newName: "UserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_User_Roles_UsersUserId",
                table: "UserRoles",
                newName: "IX_UserRoles_UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "RolesRoleId", "UsersUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RolesRoleId",
                table: "UserRoles",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UsersUserId",
                table: "UserRoles",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
