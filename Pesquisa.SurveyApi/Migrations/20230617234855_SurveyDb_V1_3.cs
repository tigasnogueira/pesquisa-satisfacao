using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pesquisa.SurveyApi.Migrations
{
    /// <inheritdoc />
    public partial class SurveyDb_V1_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_Customer_CustomerId",
                table: "Evaluation");

            migrationBuilder.DropIndex(
                name: "IX_Evaluation_CustomerId",
                table: "Evaluation");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerModelId",
                table: "Evaluation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_CustomerModelId",
                table: "Evaluation",
                column: "CustomerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluation_Customer_CustomerModelId",
                table: "Evaluation",
                column: "CustomerModelId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluation_Customer_CustomerModelId",
                table: "Evaluation");

            migrationBuilder.DropIndex(
                name: "IX_Evaluation_CustomerModelId",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "CustomerModelId",
                table: "Evaluation");

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
    }
}
