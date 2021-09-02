using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Data.Migrations
{
  public partial class SeedData : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "Books",
          columns: new[] { "Id", "Name", "Text", "Price" },
          values: new object[] { 1, "12 Rules", "12 Rules for Life", 259.99 }
          );

      migrationBuilder.InsertData(
          table: "Users",
          columns: new[] { "Id", "UserName", "Email", "FirstName", "LastName" },
          values: new object[] { 1, "marnoux", "marnouxmanser@gmail.com", "Marnoux", "Manser" }
          );

      migrationBuilder.InsertData(
          table: "Subscriptions",
          columns: new[] { "Id", "DateAdded", "BookId", "AppUserId" },
          values: new object[] { 1, DateTime.Now.ToString(), 1, 1 }
          );
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
