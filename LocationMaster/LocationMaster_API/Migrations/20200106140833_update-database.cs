using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationMaster_API.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("1b6ecbed-1081-4afe-9796-62eb943df9ef"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("d85f1eb4-8915-4a9d-9fff-8169b31f423a"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("ffe99564-0f84-41e5-b7c8-c212d4cb4ab9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("5f3824b1-3f62-4273-a163-298159ad632e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("8464f6b3-b1b4-43a6-9139-0b7bd06dc0d2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f6d6642e-8e2b-411a-a490-3fe4258d3743"));

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PhotoId", "Path", "PlaceId" },
                values: new object[,]
                {
                    { new Guid("5d8fb316-4396-42c1-9952-f8fe8b9ae240"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("4d69e633-4bce-4a63-a4c5-cd3103b35bdd"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("688409bf-57e8-4df5-9ee6-d0b593ea4348"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AllowedRoles", "BirthDate", "Email", "FirstName", "LastName", "Password", "ProfileImagePhotoId", "Username" },
                values: new object[,]
                {
                    { new Guid("1b83de78-0045-4f31-aefd-246c18796bb6"), new[] { "admin" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Comanel", "Gigica", "$MYHASH$V1$10000$BEoOdRW6A3rRySmylH/Q0aaeRhnsJPtK7VMBITIgs8Ybu31jj8Om/Cy0EJVP7BzQJ3kktKSzc8QuwKtE11wXrwdUD28/jpt7DY5EJX06IEM=", null, "admin" },
                    { new Guid("d110da85-88ec-4a54-89fa-0ee23229e410"), new[] { "moderator" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moderator@gmail.com", "Comanel", "Jhony", "$MYHASH$V1$10000$V8IJBMrz7ltaAPDVLz2EJlcbwF2m8Rq4UvjNXOiyRO+9h/nrhpvs6XXPPFAdOTxKSXzRkewwXpmAGspPhbM74PFZ+a7BkaaP+l9agFUYKMU=", null, "moderator" },
                    { new Guid("c1b6de33-dbda-4d7b-9dca-de8db5445912"), new[] { "user" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", "Comanel", "Florinel", "$MYHASH$V1$10000$WBgm2Kaw6cBOlSZsP9sbLAdlJ1VOn3lEWGh/JMMc2uGixD9NyE90H0wm4b8SenOgiD/yGl6nD+T6Z4Wxa71KD1l1pMlE6M8Dk+rULixX1pA=", null, "user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("4d69e633-4bce-4a63-a4c5-cd3103b35bdd"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("5d8fb316-4396-42c1-9952-f8fe8b9ae240"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("688409bf-57e8-4df5-9ee6-d0b593ea4348"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("1b83de78-0045-4f31-aefd-246c18796bb6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("c1b6de33-dbda-4d7b-9dca-de8db5445912"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("d110da85-88ec-4a54-89fa-0ee23229e410"));

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "PhotoId", "Path", "PlaceId" },
                values: new object[,]
                {
                    { new Guid("ffe99564-0f84-41e5-b7c8-c212d4cb4ab9"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("d85f1eb4-8915-4a9d-9fff-8169b31f423a"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("1b6ecbed-1081-4afe-9796-62eb943df9ef"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AllowedRoles", "BirthDate", "Email", "FirstName", "LastName", "Password", "ProfileImagePhotoId", "Username" },
                values: new object[,]
                {
                    { new Guid("5f3824b1-3f62-4273-a163-298159ad632e"), new[] { "admin" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Comanel", "Gigica", "$MYHASH$V1$10000$uT6Y0zerRx5azrQHfL+AaBLbMF3kdgJjjztzpBCUaYHqonIYxJQSWJPEihpEUX5e72SbEjTGcFZUJ2LC4f22oAun8/KbH6S/jGinh+307Lg=", null, "admin" },
                    { new Guid("f6d6642e-8e2b-411a-a490-3fe4258d3743"), new[] { "moderator" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moderator@gmail.com", "Comanel", "Jhony", "$MYHASH$V1$10000$r5FOAa+8/PzG3gCrPQccj3H6mcFd4LqwGox5MD5NdpKJ0Mi0TbdYVhEARJhyaZ8Ah3AXVvD7hwtl6tEwer2tAG6RI4T/IXlXUXR3mYGW1rQ=", null, "moderator" },
                    { new Guid("8464f6b3-b1b4-43a6-9139-0b7bd06dc0d2"), new[] { "user" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", "Comanel", "Florinel", "$MYHASH$V1$10000$KkH0ExPCpZlVjOV37w2ZZT5L8fADjyIW1frRGHVN5dyn7nHUGtL1xhNh607zV22IsNoFd1+O5Nw+I7qxcbFHIihNX90zKB5o4udYZlnbMAQ=", null, "user" }
                });
        }
    }
}
