using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class secondone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_rolesRoleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_usersUserId",
                table: "RoleUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "RoleUser",
                newName: "UserRoles");

            migrationBuilder.RenameColumn(
                name: "usersUserId",
                table: "UserRoles",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "rolesRoleId",
                table: "UserRoles",
                newName: "RolesRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_usersUserId",
                table: "UserRoles",
                newName: "IX_UserRoles_UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "RolesRoleId", "UsersUserId" });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    permissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    permissionName = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.permissionId);
                    table.ForeignKey(
                        name: "FK_Permission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenId = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    Expiracy_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    scopes = table.Column<List<string>>(type: "text[]", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RoleId",
                table: "Permission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RolesRoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UsersUserId",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "RoleUser",
                newName: "usersUserId");

            migrationBuilder.RenameColumn(
                name: "RolesRoleId",
                table: "RoleUser",
                newName: "rolesRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_UsersUserId",
                table: "RoleUser",
                newName: "IX_RoleUser_usersUserId");

            migrationBuilder.AddColumn<List<string>>(
                name: "Permissions",
                table: "Roles",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleUser",
                table: "RoleUser",
                columns: new[] { "rolesRoleId", "usersUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_rolesRoleId",
                table: "RoleUser",
                column: "rolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_usersUserId",
                table: "RoleUser",
                column: "usersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
