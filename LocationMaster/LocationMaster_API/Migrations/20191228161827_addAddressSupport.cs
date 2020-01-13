using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocationMaster_API.Migrations
{
    public partial class addAddressSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<Guid>(nullable: false),
                    OwnerUserId = table.Column<Guid>(nullable: true),
                    LocationName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: true),
                    TicketPrice = table.Column<float>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Places_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    PlaceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    AttractionId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PhotoId = table.Column<Guid>(nullable: true),
                    PlaceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.AttractionId);
                    table.ForeignKey(
                        name: "FK_Attractions_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attractions_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ProfileImagePhotoId = table.Column<Guid>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    AllowedRoles = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Photos_ProfileImagePhotoId",
                        column: x => x.ProfileImagePhotoId,
                        principalTable: "Photos",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    PlaceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_PhotoId",
                table: "Attractions",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Attractions_PlaceId",
                table: "Attractions",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PlaceId",
                table: "Photos",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CategoryId",
                table: "Places",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_OwnerUserId",
                table: "Places",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PlaceId",
                table: "Reviews",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileImagePhotoId",
                table: "Users",
                column: "ProfileImagePhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_OwnerUserId",
                table: "Places",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Photos_ProfileImagePhotoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
