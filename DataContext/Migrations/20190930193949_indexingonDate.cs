using Microsoft.EntityFrameworkCore.Migrations;

namespace DataContext.Migrations
{
    public partial class indexingonDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MessagesOfTheDay_ShowOn",
                table: "MessagesOfTheDay",
                column: "ShowOn",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MessagesOfTheDay_ShowOn",
                table: "MessagesOfTheDay");
        }
    }
}
