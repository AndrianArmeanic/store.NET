using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("94ca0610-1e10-4354-834c-1fc2e89b54fd"), new DateTimeOffset(new DateTime(2022, 8, 1, 12, 19, 26, 95, DateTimeKind.Unspecified).AddTicks(8221), new TimeSpan(0, 3, 0, 0, 0)), "Some description about first product", "Product_1", 0m },
                    { new Guid("ba1f28f1-1d3a-420e-8425-328f86e0cdf6"), new DateTimeOffset(new DateTime(2022, 8, 1, 12, 19, 26, 95, DateTimeKind.Unspecified).AddTicks(8269), new TimeSpan(0, 3, 0, 0, 0)), "Some description about second product", "Product_2", 0m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { new Guid("262f23cc-6135-4f4c-942e-baf59acfcca2"), new DateTimeOffset(new DateTime(2022, 8, 1, 12, 19, 26, 95, DateTimeKind.Unspecified).AddTicks(9400), new TimeSpan(0, 3, 0, 0, 0)), "username2@gmail.com", "Iw2qLeC1DLXuJmHetNVKvut0120ZQnXg2tK/uk0Yaw8=", "Username_2" },
                    { new Guid("9033b2f9-4225-48f1-b981-30bdebbb316b"), new DateTimeOffset(new DateTime(2022, 8, 1, 12, 19, 26, 95, DateTimeKind.Unspecified).AddTicks(8776), new TimeSpan(0, 3, 0, 0, 0)), "username1@gmail.com", "Iw2qLeC1DLXuJmHetNVKvut0120ZQnXg2tK/uk0Yaw8=", "Username_1" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "ProductId", "UserId" },
                values: new object[,]
                {
                    { new Guid("52b9250d-eae2-46b7-b8e8-c9383903fcdb"), new DateTimeOffset(new DateTime(2022, 8, 1, 12, 19, 26, 95, DateTimeKind.Unspecified).AddTicks(9499), new TimeSpan(0, 3, 0, 0, 0)), new Guid("94ca0610-1e10-4354-834c-1fc2e89b54fd"), new Guid("9033b2f9-4225-48f1-b981-30bdebbb316b") },
                    { new Guid("d5463836-4b8d-42da-8424-d7e3f275b840"), new DateTimeOffset(new DateTime(2022, 8, 1, 12, 19, 26, 95, DateTimeKind.Unspecified).AddTicks(9515), new TimeSpan(0, 3, 0, 0, 0)), new Guid("94ca0610-1e10-4354-834c-1fc2e89b54fd"), new Guid("262f23cc-6135-4f4c-942e-baf59acfcca2") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
