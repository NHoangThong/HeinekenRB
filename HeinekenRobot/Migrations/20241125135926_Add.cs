using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeinekenRobot.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecycleMachineMachineId",
                table: "GiftRedemptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiftRedemptions_RecycleMachineMachineId",
                table: "GiftRedemptions",
                column: "RecycleMachineMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftRedemptions_RecycleMachines_RecycleMachineMachineId",
                table: "GiftRedemptions",
                column: "RecycleMachineMachineId",
                principalTable: "RecycleMachines",
                principalColumn: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiftRedemptions_RecycleMachines_RecycleMachineMachineId",
                table: "GiftRedemptions");

            migrationBuilder.DropIndex(
                name: "IX_GiftRedemptions_RecycleMachineMachineId",
                table: "GiftRedemptions");

            migrationBuilder.DropColumn(
                name: "RecycleMachineMachineId",
                table: "GiftRedemptions");
        }
    }
}
