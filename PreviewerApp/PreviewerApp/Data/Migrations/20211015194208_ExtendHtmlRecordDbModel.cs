// <copyright file="20211015194208_ExtendHtmlRecordDbModel.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ExtendHtmlRecordDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShareableUrl",
                table: "HtmlRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShareableUrl",
                table: "HtmlRecords");
        }
    }
}