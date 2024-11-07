using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeinekenRobot.Migrations
{
    public partial class SeedRobotTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RobotType",
                columns: new[] { "RobotTypeId", "TypeName" },
                values: new object[] { "1", "Silverbot" });

            migrationBuilder.InsertData(
                table: "RobotType",
                columns: new[] { "RobotTypeId", "TypeName" },
                values: new object[] { "2", "DeliveryBox" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RobotType",
                keyColumn: "RobotTypeId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "RobotType",
                keyColumn: "RobotTypeId",
                keyValue: "2");
        }
    }
}
