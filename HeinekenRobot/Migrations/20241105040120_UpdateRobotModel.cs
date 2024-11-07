using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeinekenRobot.Migrations
{
    public partial class UpdateRobotModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RobotCode",
                table: "Robots");

            migrationBuilder.RenameColumn(
                name: "RobotType",
                table: "Robots",
                newName: "RobotName");

            migrationBuilder.AddColumn<string>(
                name: "RobotTypeId",
                table: "Robots",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RobotType",
                columns: table => new
                {
                    RobotTypeId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotType", x => x.RobotTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Robots_RobotTypeId",
                table: "Robots",
                column: "RobotTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_RobotType_RobotTypeId",
                table: "Robots",
                column: "RobotTypeId",
                principalTable: "RobotType",
                principalColumn: "RobotTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robots_RobotType_RobotTypeId",
                table: "Robots");

            migrationBuilder.DropTable(
                name: "RobotType");

            migrationBuilder.DropIndex(
                name: "IX_Robots_RobotTypeId",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "RobotTypeId",
                table: "Robots");

            migrationBuilder.RenameColumn(
                name: "RobotName",
                table: "Robots",
                newName: "RobotType");

            migrationBuilder.AddColumn<string>(
                name: "RobotCode",
                table: "Robots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
