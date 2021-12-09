using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_Managerment_SystemMarket_Core.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "Lectures",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6388), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6399) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6407), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6410) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6414), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6416) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6421), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6427), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6429) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6434), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6436) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6440), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6442) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6446), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6449) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6453), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6456) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6460), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6462) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6466), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6469) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6473), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6476) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6480), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6482) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6486), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6488) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6493), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6499), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6502) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6506), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6508) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6512), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6515) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6519), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6521) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6525), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6528) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6532), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6534) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6544), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6547) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6550), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6557), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6563), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6566) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6570), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6572) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6576), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6579) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6583), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6585) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6589), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6591) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6595), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6598) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6601), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6607), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(6610) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(5908), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(5941) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(5951), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(5954) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(5960), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(5963) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6086), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6090) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6094), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6097) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6100), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6103) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6107), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6109) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6114), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6121), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6124) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6129), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6131) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6135), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6142), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6144) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6148), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(9567), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(9579) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(9587), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(9590) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 972, DateTimeKind.Local).AddTicks(3055), new DateTime(2021, 12, 8, 15, 26, 48, 975, DateTimeKind.Local).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 975, DateTimeKind.Local).AddTicks(2283), new DateTime(2021, 12, 8, 15, 26, 48, 975, DateTimeKind.Local).AddTicks(2298) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 975, DateTimeKind.Local).AddTicks(2303), new DateTime(2021, 12, 8, 15, 26, 48, 975, DateTimeKind.Local).AddTicks(2307) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4025), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4046), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4049) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4055), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4057) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4062), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4065) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4069), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4072) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4077), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4084), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4091), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4094) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4098), new DateTime(2021, 12, 8, 15, 26, 48, 979, DateTimeKind.Local).AddTicks(4101) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fc85aa59-4f78-4426-b023-f5e422eaa552");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9774), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9788) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9798), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9801) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9806), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9808) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9812), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9815) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9820), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9828), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9831) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9835), new DateTime(2021, 12, 8, 15, 26, 48, 978, DateTimeKind.Local).AddTicks(9838) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Video",
                table: "Lectures");

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9031), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9067), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9071) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9076), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9080) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9086), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9095), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9098) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9104), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9107) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9112), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9115) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9120), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9124) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9129), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9133) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9138), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9142) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9147), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9155), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9163), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9167) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9172), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9176) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9182), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9186) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9191), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9200), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9208), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9216), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9225), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9233), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9236) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9244), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9247) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9252), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9256) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9261), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9270), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9279), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9282) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9287), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9295), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9299) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9303), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9307) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9313), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9317) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9322), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "AdminSettings",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9330), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(9334) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6118), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6153) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6163), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6167) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6175), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6184), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6188) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6193), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6196) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6201), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6205) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6210), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6214) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6219), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6223) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6228), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6232) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6237), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6241) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6246), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6254), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6258) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6263), new DateTime(2021, 12, 3, 16, 42, 1, 925, DateTimeKind.Local).AddTicks(6267) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 927, DateTimeKind.Local).AddTicks(3207), new DateTime(2021, 12, 3, 16, 42, 1, 927, DateTimeKind.Local).AddTicks(3231) });

            migrationBuilder.UpdateData(
                table: "FAQs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 927, DateTimeKind.Local).AddTicks(3242), new DateTime(2021, 12, 3, 16, 42, 1, 927, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 913, DateTimeKind.Local).AddTicks(6383), new DateTime(2021, 12, 3, 16, 42, 1, 917, DateTimeKind.Local).AddTicks(2802) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 917, DateTimeKind.Local).AddTicks(3886), new DateTime(2021, 12, 3, 16, 42, 1, 917, DateTimeKind.Local).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 917, DateTimeKind.Local).AddTicks(3905), new DateTime(2021, 12, 3, 16, 42, 1, 917, DateTimeKind.Local).AddTicks(3909) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5484), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5513) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5523), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5528) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5533), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5537) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5542), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5545) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5551), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5554) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5560), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5563) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5569), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5573) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5578), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "NotificationTemplates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5587), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(5591) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d0adcb19-d027-4db6-8430-7eff9da9afc8");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(13), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(42) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(51), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(61), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(65) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(70), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(73) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(267), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(278), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(282) });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(287), new DateTime(2021, 12, 3, 16, 42, 1, 926, DateTimeKind.Local).AddTicks(291) });
        }
    }
}
