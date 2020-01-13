using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationMaster_API.Migrations
{
    public partial class ceva_jmenar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("6b54beff-df42-48b0-a1cd-bb1e82a078b7"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("8a74d481-9e1c-4e4f-9c3c-f49506b69a38"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("1d4c6957-9fa0-46dc-9a04-a714eafba70e"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AllowedRoles", "BirthDate", "Email", "FirstName", "LastName", "Password", "ProfileImagePhotoId", "Username" },
                values: new object[,]
                {
                    { new Guid("1988ca44-9533-488d-b50a-e75d26da78a5"), new[] { "admin" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Comanel", "Gigica", "$MYHASH$V1$10000$hwapC7G1RBS9iHOHq/P58jUV3mg8ncqKFaNj0o1gqm+JX8gzs0ce3LEgpmFMjLNdFpgUWJEsikP8gIisSHyDfIl6vYMl5KVVvRML2jEfSG8=", "6b54beff-df42-48b0-a1cd-bb1e82a078b7", "admin" },
                    { new Guid("ceab63b6-95db-4765-8fbb-e3b8640b10f1"), new[] { "moderator" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moderator@gmail.com", "Comanel", "Jhony", "$MYHASH$V1$10000$+efBlE4CCzGlYTQyr0wkTBCuHDvAeU1DMCBdrP61ubZ4lwvAuyKbro8HzOxPtuPrtCMePDYkZoeLXhezYjiwm3qtxy/qgxNwsPZOwFdwxeo=", "8a74d481-9e1c-4e4f-9c3c-f49506b69a38", "moderator" },
                    { new Guid("a2d5e9bd-4dd7-40f9-83d3-5cfcfb19645c"), new[] { "user" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", "Comanel", "Florinel", "$MYHASH$V1$10000$UvjXnB+I3gAj8svnSgb7uIALZvjwt5dvEH7NbLU+X1BWpup6O/eUx1ncHCC3Jnrtq+dQuNFovZKAIEL+z3PVxRVzJ1TVzZsVN4xPHooz1HQ=", "1d4c6957-9fa0-46dc-9a04-a714eafba70e", "user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("1d4c6957-9fa0-46dc-9a04-a714eafba70e"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("6b54beff-df42-48b0-a1cd-bb1e82a078b7"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("8a74d481-9e1c-4e4f-9c3c-f49506b69a38"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("1988ca44-9533-488d-b50a-e75d26da78a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("a2d5e9bd-4dd7-40f9-83d3-5cfcfb19645c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ceab63b6-95db-4765-8fbb-e3b8640b10f1"));

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
    }
}
