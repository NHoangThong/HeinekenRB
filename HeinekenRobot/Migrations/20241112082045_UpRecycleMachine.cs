using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeinekenRobot.Migrations
{
    public partial class UpRecycleMachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RobotType",
                keyColumn: "RobotTypeId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "RobotType",
                keyColumn: "RobotTypeId",
                keyValue: "2");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RecycleMachines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Interactions",
                table: "RecycleMachines",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RecycleMachines");

            migrationBuilder.DropColumn(
                name: "Interactions",
                table: "RecycleMachines");

            migrationBuilder.InsertData(
                table: "RobotType",
                columns: new[] { "RobotTypeId", "TypeName" },
                values: new object[] { "1", "Silverbot" });

            migrationBuilder.InsertData(
                table: "RobotType",
                columns: new[] { "RobotTypeId", "TypeName" },
                values: new object[] { "2", "DeliveryBox" });
        }
    }
}
