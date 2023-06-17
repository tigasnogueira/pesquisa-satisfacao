using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pesquisa.SurveyApi.Migrations
{
    /// <inheritdoc />
    public partial class SurveyDb_V1_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_CustomerId",
                table: "Evaluation",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_Customer_CustomerId",
                table: "Evaluation",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_Customer_CustomerId",
                table: "Evaluation");

            migrationBuilder.DropIndex(
                name: "IX_Evaluation_CustomerId",
                table: "Evaluation");
        }
    }
}
