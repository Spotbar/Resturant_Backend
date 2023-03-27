using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resturant_Backend.Domain.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateCredits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateCredits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpratorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    JoinDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FactorNummber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactorDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeliveryCost = table.Column<long>(type: "bigint", nullable: false),
                    FactorAmount = table.Column<long>(type: "bigint", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    IsDeliveryByCompany = table.Column<bool>(type: "bit", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factors_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<long>(type: "bigint", nullable: false),
                    IsShared = table.Column<bool>(type: "bit", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    FactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Factors_FactorId",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DateCredits",
                columns: new[] { "Id", "Amount", "IsEnable", "Year" },
                values: new object[,]
                {
                    { new Guid("8646863f-2d44-4b43-828d-edaa27de5de5"), 100000, false, "1401" },
                    { new Guid("d9ecf8ae-7ed6-405b-a9ba-30ef1fd745ff"), 100000, true, "1402" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e09fc5e-7b3b-4347-abac-ada8d34c23ab"), "IT" },
                    { new Guid("6b489010-b02f-4c5a-b22c-ef7d3a49559c"), "لجستیک" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Mobile", "Name", "OpratorName", "Tel" },
                values: new object[,]
                {
                    { new Guid("4fd22246-6cea-4822-bcec-dec5f25e4d31"), null, null, "گلی خانم", null, "0831" },
                    { new Guid("f2c8a076-6a05-4671-b4dd-b4a90c47db31"), null, null, "پارسی", null, "0831" },
                    { new Guid("f7ee871d-a62c-44c9-a1e7-b511d1f454bd"), null, null, "باغ گیلاس", null, "0831" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsEnable", "JoinDate", "Name", "NationalCode", "Password", "Post" },
                values: new object[,]
                {
                    { new Guid("61e68580-c217-4e24-bb1e-89cfd0b20737"), true, new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7639), new TimeSpan(0, 3, 30, 0, 0)), "حسن الفت", "3240486611", "", null },
                    { new Guid("b2771cc8-1533-417e-85c5-a762a3065227"), true, new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7665), new TimeSpan(0, 3, 30, 0, 0)), "الهام شهری", "", "", null }
                });

            migrationBuilder.InsertData(
                table: "Factors",
                columns: new[] { "Id", "DeliveryCost", "FactorAmount", "FactorDate", "FactorNummber", "IsClosed", "IsDeliveryByCompany", "RestaurantId" },
                values: new object[,]
                {
                    { new Guid("3fa388a0-12a4-4446-a1ef-3523d00bba51"), 15000L, 200000L, new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7691), new TimeSpan(0, 3, 30, 0, 0)), "-1", false, false, new Guid("4fd22246-6cea-4822-bcec-dec5f25e4d31") },
                    { new Guid("9a74ab0b-10f6-4bc0-b80a-e98cbd761b70"), 15000L, 200000L, new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7738), new TimeSpan(0, 3, 30, 0, 0)), "-1", false, false, new Guid("f2c8a076-6a05-4671-b4dd-b4a90c47db31") },
                    { new Guid("d2e9c135-b391-4e1b-9580-eddd84c08a5b"), 15000L, 200000L, new DateTimeOffset(new DateTime(2023, 3, 22, 9, 6, 0, 140, DateTimeKind.Unspecified).AddTicks(7735), new TimeSpan(0, 3, 30, 0, 0)), "-1", false, false, new Guid("f7ee871d-a62c-44c9-a1e7-b511d1f454bd") }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "GroupId", "UserId" },
                values: new object[,]
                {
                    { new Guid("04032e9b-6157-4947-b191-b69bd899fa8d"), new Guid("0e09fc5e-7b3b-4347-abac-ada8d34c23ab"), new Guid("61e68580-c217-4e24-bb1e-89cfd0b20737") },
                    { new Guid("fe4be73e-d6ed-46de-9f30-db8ea6c13c8d"), new Guid("0e09fc5e-7b3b-4347-abac-ada8d34c23ab"), new Guid("b2771cc8-1533-417e-85c5-a762a3065227") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Cost", "FactorId", "IsAccept", "IsShared", "Name" },
                values: new object[,]
                {
                    { new Guid("1a90e91e-7bbf-4001-accc-00663b5ce552"), 800000L, new Guid("3fa388a0-12a4-4446-a1ef-3523d00bba51"), true, true, "عدس پلو" },
                    { new Guid("8790654e-07b2-4575-b1e7-529e637d6047"), 120000L, new Guid("3fa388a0-12a4-4446-a1ef-3523d00bba51"), true, false, "کوبیده" }
                });

            migrationBuilder.InsertData(
                table: "UserOrders",
                columns: new[] { "Id", "Amount", "OrderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5c813bb4-0285-429b-9303-ec5c29b1c90a"), 40000L, new Guid("1a90e91e-7bbf-4001-accc-00663b5ce552"), new Guid("61e68580-c217-4e24-bb1e-89cfd0b20737") },
                    { new Guid("73059b2e-802c-44dd-affc-7d1ff99de4c2"), 40000L, new Guid("1a90e91e-7bbf-4001-accc-00663b5ce552"), new Guid("b2771cc8-1533-417e-85c5-a762a3065227") },
                    { new Guid("85e2b7be-5425-46a5-a7f2-d3ea63cd93d1"), 120000L, new Guid("8790654e-07b2-4575-b1e7-529e637d6047"), new Guid("61e68580-c217-4e24-bb1e-89cfd0b20737") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Factors_RestaurantId",
                table: "Factors",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FactorId",
                table: "Orders",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_UserId",
                table: "UserGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_OrderId",
                table: "UserOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_UserId",
                table: "UserOrders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateCredits");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserOrders");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
