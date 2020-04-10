// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeoApi.Migrations
{
    public partial class AddingGeos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Geos");
        }
    }
}
