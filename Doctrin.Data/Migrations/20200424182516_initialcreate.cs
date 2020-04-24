using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctrin.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Units_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendar_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GlobalId = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Inheritable = table.Column<bool>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    CalendarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExceptionDay_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionSetting",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    SettingId = table.Column<string>(nullable: true),
                    ExceptionDayId = table.Column<int>(nullable: false),
                    SettingId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExceptionSetting_ExceptionDay_ExceptionDayId",
                        column: x => x.ExceptionDayId,
                        principalTable: "ExceptionDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExceptionSetting_Settings_SettingId1",
                        column: x => x.SettingId1,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1, "Root", null });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "GlobalId", "Inheritable", "UnitId", "Value" },
                values: new object[] { 1, "Opening Hours", false, 1, "9:00-17:00" });

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_UnitId",
                table: "Calendar",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionDay_CalendarId",
                table: "ExceptionDay",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionSetting_ExceptionDayId",
                table: "ExceptionSetting",
                column: "ExceptionDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionSetting_SettingId1",
                table: "ExceptionSetting",
                column: "SettingId1");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_UnitId_GlobalId",
                table: "Settings",
                columns: new[] { "UnitId", "GlobalId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentId",
                table: "Units",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionSetting");

            migrationBuilder.DropTable(
                name: "ExceptionDay");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
