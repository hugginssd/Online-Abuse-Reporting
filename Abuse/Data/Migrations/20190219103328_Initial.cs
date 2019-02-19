using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Abuse.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complain",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accused = table.Column<string>(maxLength: 60, nullable: false),
                    AddressOfAccussed = table.Column<string>(maxLength: 200, nullable: true),
                    AddressOfVictim = table.Column<string>(maxLength: 200, nullable: true),
                    DateOfIncident = table.Column<DateTime>(nullable: false),
                    PlaceOfIncident = table.Column<string>(maxLength: 200, nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    VictimName = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complain", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complain");
        }
    }
}
