using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredPartDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Part_Posts_PostId",
                table: "Part");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Part",
                table: "Part");

            migrationBuilder.DropIndex(
                name: "IX_Part_PostId",
                table: "Part");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Part");

            migrationBuilder.RenameTable(
                name: "Part",
                newName: "SpecialParts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SpecialParts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialParts",
                table: "SpecialParts",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialParts",
                table: "SpecialParts");

            migrationBuilder.RenameTable(
                name: "SpecialParts",
                newName: "Part");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Part",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Part",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Part",
                table: "Part",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Part_PostId",
                table: "Part",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Posts_PostId",
                table: "Part",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
