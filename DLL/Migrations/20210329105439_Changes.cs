using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Statistics_StatisticsId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "StatisticsId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Statistics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistics_Users_UserId",
                table: "Statistics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Statistics_StatisticsId",
                table: "Users",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistics_Users_UserId",
                table: "Statistics");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Statistics_StatisticsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_UserId",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Statistics");

            migrationBuilder.AlterColumn<int>(
                name: "StatisticsId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Statistics_StatisticsId",
                table: "Users",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
