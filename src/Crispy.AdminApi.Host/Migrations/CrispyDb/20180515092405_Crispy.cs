using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Crispy.AdminApi.Host.Migrations.CrispyDb
{
    public partial class Crispy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Enabler = table.Column<bool>(nullable: false),
                    Encryption = table.Column<bool>(nullable: false),
                    IncludeGlobalConfig = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicatoinId = table.Column<Guid>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Enabler = table.Column<bool>(nullable: false),
                    Encryption = table.Column<bool>(nullable: false),
                    IncludeGlobalConfig = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Environments_Applications_ApplicatoinId",
                        column: x => x.ApplicatoinId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicationId = table.Column<Guid>(nullable: true),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Enabler = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(maxLength: 50, nullable: false),
                    Value = table.Column<string>(maxLength: 1280, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variables_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "KeyValuePairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplyType = table.Column<int>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Enabler = table.Column<bool>(nullable: false),
                    EnvironmentId = table.Column<Guid>(nullable: true),
                    Key = table.Column<string>(maxLength: 50, nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Value = table.Column<string>(maxLength: 1280, nullable: true),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyValuePairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyValuePairs_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "KeyValuePairHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTimeCreated = table.Column<DateTime>(nullable: false),
                    KeyValuePairId = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(maxLength: 1280, nullable: true),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyValuePairHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyValuePairHistories_KeyValuePairs_KeyValuePairId",
                        column: x => x.KeyValuePairId,
                        principalTable: "KeyValuePairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Environments_ApplicatoinId",
                table: "Environments",
                column: "ApplicatoinId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyValuePairHistories_KeyValuePairId",
                table: "KeyValuePairHistories",
                column: "KeyValuePairId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyValuePairs_EnvironmentId",
                table: "KeyValuePairs",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Variables_ApplicationId",
                table: "Variables",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyValuePairHistories");

            migrationBuilder.DropTable(
                name: "Variables");

            migrationBuilder.DropTable(
                name: "KeyValuePairs");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "Applications");
        }
    }
}
