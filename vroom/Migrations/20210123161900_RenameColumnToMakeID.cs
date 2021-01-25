using Microsoft.EntityFrameworkCore.Migrations;

namespace vroom.Migrations
{
    public partial class RenameColumnToMakeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeFK",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "MakeFK",
                table: "Models",
                newName: "MakeID");

            migrationBuilder.RenameIndex(
                name: "IX_Models_MakeFK",
                table: "Models",
                newName: "IX_Models_MakeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeID",
                table: "Models",
                column: "MakeID",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeID",
                table: "Models");

            migrationBuilder.RenameColumn(
                name: "MakeID",
                table: "Models",
                newName: "MakeFK");

            migrationBuilder.RenameIndex(
                name: "IX_Models_MakeID",
                table: "Models",
                newName: "IX_Models_MakeFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeFK",
                table: "Models",
                column: "MakeFK",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
