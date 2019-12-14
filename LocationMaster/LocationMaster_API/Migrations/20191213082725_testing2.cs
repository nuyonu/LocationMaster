using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationMaster_API.Migrations
{
    public partial class testing2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("22922280-4342-48ad-913e-3f1ea8bd3e45"));

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PhotoId", "Path", "PlaceId" },
                values: new object[,]
                {
                    { new Guid("336d8d66-890b-46e5-8b99-12a023ceaf61"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("56d87564-6bcd-460a-a9cc-29c1ba6107f0"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("50e1878c-93a2-4faf-b28c-87986bcde6ea"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AllowedRoles", "BirthDate", "Email", "FirstName", "LastName", "Password", "ProfileImagePhotoId", "Username" },
                values: new object[,]
                {
                    { new Guid("c4b4e421-7e5f-4c1b-8e0a-8d596ad16e42"), new[] { "admin" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Comanel", "Gigica", "$MYHASH$V1$10000$3gQfcguEDVDBNEnZvWUDrw1P24JFpm8Das4mBKaH/V3EmyB7RWGY2YesNXW+Zt/Fpb4dYXrJMvf4+eLVObiKOxS/YkLbtEGseRNF5b/Fy1M=", null, "admin" },
                    { new Guid("76041363-5aae-4b0f-b6a5-ef99c0c30913"), new[] { "moderator" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moderator@gmail.com", "Comanel", "Jhony", "$MYHASH$V1$10000$zDLPe7ubg37pxgy1K8i22n/a5aPqSygI8eFYhEeoA+7glN5EM8fqVZlu2eZl9/gPI5eSo/OdMP6mbbKGAebqeKcWDz0i10305TwDO2WlSJQ=", null, "moderator" },
                    { new Guid("673c40c5-c3b5-43a5-9cf3-223029cd1a15"), new[] { "user" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", "Comanel", "Florinel", "$MYHASH$V1$10000$oGUYu0uwpOr4awBE/vrb9Se0B8v4ohb7M43mYbczgShkWplw+EZtpitZqFAIc3QHBY9oya/JY/g+oRenrDp3Ds2rhKwbyLRWel+Fly5mJ/I=", null, "user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("336d8d66-890b-46e5-8b99-12a023ceaf61"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("50e1878c-93a2-4faf-b28c-87986bcde6ea"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("56d87564-6bcd-460a-a9cc-29c1ba6107f0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("673c40c5-c3b5-43a5-9cf3-223029cd1a15"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("76041363-5aae-4b0f-b6a5-ef99c0c30913"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("c4b4e421-7e5f-4c1b-8e0a-8d596ad16e42"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AllowedRoles", "BirthDate", "Email", "FirstName", "LastName", "Password", "ProfileImagePhotoId", "Username" },
                values: new object[] { new Guid("22922280-4342-48ad-913e-3f1ea8bd3e45"), new[] { "admin", "useredit", "roleedit" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Comanel", "Gigica", "$MYHASH$V1$10000$7eq3Pet74/KZjP85L70spIulla6RyhmsGeZ+6UmSNvTDnosxzXH7HCSRATzVxvRcLrptCGsyv0N59YFhFwaZqAZwSdDdlConNQuSKHzLrfk=", null, "admin" });
        }
    }
}
