using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationMaster_API.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("d9b66c89-932c-4e6f-a363-0bf919a6121e"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("65a2ea00-f3f8-48f0-a1ea-30a7ff4c8c2a"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null },
                    { new Guid("ac2bb3d0-848c-4c12-abe5-371168ee7fbb"), "/StaticFiles/Images/ProfileImages/DefaultProfileImage.png", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AllowedRoles", "BirthDate", "Email", "FirstName", "LastName", "Password", "ProfileImagePhotoId", "Username" },
                values: new object[,]
                {
                    { new Guid("19a56856-18d8-4070-943a-714294e34686"), new[] { "admin" }, new DateTime(2020, 1, 12, 17, 4, 58, 872, DateTimeKind.Local).AddTicks(5439), "admin@gmail.com", "Comanel", "Gigica", "$MYHASH$V1$10000$cxGUQagJgT6k4rqJqQ0cZgQn6YX3ytnqQufGbfLl5p1yHa3neRV7k6FBJZhSEqiJEONPz1jr5JprxVd8HgrXDvM8bV3Pem02WkB+mDIyOUU=", null, "admin" },
                    { new Guid("ba237a6d-a260-43e3-afee-8222e6ea94ac"), new[] { "moderator" }, new DateTime(2020, 1, 12, 17, 4, 58, 872, DateTimeKind.Local).AddTicks(5439), "moderator@gmail.com", "Comanel", "Jhony", "$MYHASH$V1$10000$ydf/zztvARE2dboWnW2E93uh/SoQ8yoB5xo3t7TyH83o4caElR/VD5gAP3osjLIjbGsdqxkkealGMsKW3dcRbqGlETASMRnMIZ/7T6hUIvw=", null, "moderator" },
                    { new Guid("1d94f0fe-2f9d-4bbb-92b3-6e5b615e08e2"), new[] { "user" }, new DateTime(2020, 1, 12, 17, 4, 58, 872, DateTimeKind.Local).AddTicks(5439), "user@gmail.com", "Comanel", "Florinel", "$MYHASH$V1$10000$rZFp8JlPznvjq1NX+Y8OWYpQAuGfIMPU+7QatRoNVTTe2FmRCj8UuTo5FkvFVGOToQGT67c6kLJdz84n2O1E/qnpuUWgpJ4ChMCS5qZwYQ0=", null, "user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("65a2ea00-f3f8-48f0-a1ea-30a7ff4c8c2a"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("ac2bb3d0-848c-4c12-abe5-371168ee7fbb"));

            migrationBuilder.DeleteData(
                table: "Photos",
                keyColumn: "PhotoId",
                keyValue: new Guid("d9b66c89-932c-4e6f-a363-0bf919a6121e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("19a56856-18d8-4070-943a-714294e34686"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("1d94f0fe-2f9d-4bbb-92b3-6e5b615e08e2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("ba237a6d-a260-43e3-afee-8222e6ea94ac"));

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
                    { new Guid("1988ca44-9533-488d-b50a-e75d26da78a5"), new[] { "admin" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Comanel", "Gigica", "$MYHASH$V1$10000$hwapC7G1RBS9iHOHq/P58jUV3mg8ncqKFaNj0o1gqm+JX8gzs0ce3LEgpmFMjLNdFpgUWJEsikP8gIisSHyDfIl6vYMl5KVVvRML2jEfSG8=", null, "admin" },
                    { new Guid("ceab63b6-95db-4765-8fbb-e3b8640b10f1"), new[] { "moderator" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "moderator@gmail.com", "Comanel", "Jhony", "$MYHASH$V1$10000$+efBlE4CCzGlYTQyr0wkTBCuHDvAeU1DMCBdrP61ubZ4lwvAuyKbro8HzOxPtuPrtCMePDYkZoeLXhezYjiwm3qtxy/qgxNwsPZOwFdwxeo=", null, "moderator" },
                    { new Guid("a2d5e9bd-4dd7-40f9-83d3-5cfcfb19645c"), new[] { "user" }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", "Comanel", "Florinel", "$MYHASH$V1$10000$UvjXnB+I3gAj8svnSgb7uIALZvjwt5dvEH7NbLU+X1BWpup6O/eUx1ncHCC3Jnrtq+dQuNFovZKAIEL+z3PVxRVzJ1TVzZsVN4xPHooz1HQ=", null, "user" }
                });
        }
    }
}
