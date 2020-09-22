using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aircall.Migrations
{
    public partial class forst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "passes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    pass = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    Adress = table.Column<string>(nullable: true),
                    Data = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "saveProp",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    prop = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saveProp", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "passes");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "saveProp");
        }
    }
}
