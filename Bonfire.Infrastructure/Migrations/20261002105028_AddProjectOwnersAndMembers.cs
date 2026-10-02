using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bonfire.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectOwnersAndMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Projects",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                newName: "IX_Projects_OwnerId");

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    MemberProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => new { x.MemberProjectsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_MemberProjectsId",
                        column: x => x.MemberProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_MembersId",
                table: "ProjectUser",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_OwnerId",
                table: "Projects",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_OwnerId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Projects",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_OwnerId",
                table: "Projects",
                newName: "IX_Projects_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
