using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationMaster_API.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "AllowedRoles",
                table: "Users",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AllowedRoles", "BirthDate", "Email", "FirstName", "LastName", "Password", "ProfileImagePhotoId", "Username" },
                values: new object[] { new Guid("22922280-4342-48ad-913e-3f1ea8bd3e45"), new[] { "admin", "useredit", "roleedit" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Comanel", "Gigica", "$MYHASH$V1$10000$7eq3Pet74/KZjP85L70spIulla6RyhmsGeZ+6UmSNvTDnosxzXH7HCSRATzVxvRcLrptCGsyv0N59YFhFwaZqAZwSdDdlConNQuSKHzLrfk=", null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("22922280-4342-48ad-913e-3f1ea8bd3e45"));

            migrationBuilder.DropColumn(
                name: "AllowedRoles",
                table: "Users");
        }
    }
}
