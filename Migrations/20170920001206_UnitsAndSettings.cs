using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VanillaPuddingAPI.Migrations
{
    public partial class UnitsAndSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Clients_ClientId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_ClientId",
                table: "Contacts",
                newName: "IX_Contacts_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ContactId");

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "UnitSettings",
                columns: table => new
                {
                    UnitSettingId = table.Column<int>(type: "int4", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BoolValue = table.Column<bool>(type: "bool", nullable: false),
                    IntValue = table.Column<int>(type: "int4", nullable: false),
                    StringValue = table.Column<string>(type: "text", nullable: true),
                    UnitId = table.Column<int>(type: "int4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitSettings", x => x.UnitSettingId);
                    table.ForeignKey(
                        name: "FK_UnitSettings_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UnitSettings_UnitId",
                table: "UnitSettings",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Clients_ClientId",
                table: "Contacts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Clients_ClientId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "UnitSettings");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_ClientId",
                table: "Contact",
                newName: "IX_Contact_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Clients_ClientId",
                table: "Contact",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
