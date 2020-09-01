using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstagramTokenRefresh.Migrations
{
    public partial class date_modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expires",
                table: "Tokens");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Tokens",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Tokens");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expires",
                table: "Tokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
