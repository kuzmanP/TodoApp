using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Tasks_TaskId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_TaskId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Person");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PersonId",
                table: "Tasks",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Person_PersonId",
                table: "Tasks",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Person_PersonId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PersonId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "Person",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_TaskId",
                table: "Person",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Tasks_TaskId",
                table: "Person",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
