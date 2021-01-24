using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionThree.WebApp.Migrations
{
    public partial class DatesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Transactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Transactions",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Transactions");
        }
    }
}
