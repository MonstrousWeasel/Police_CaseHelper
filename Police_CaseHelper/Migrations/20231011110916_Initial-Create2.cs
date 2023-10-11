using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Police_CaseHelper.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VictimName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OffenderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Charges = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffenderPlea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OffenderInCustody = table.Column<bool>(type: "bit", nullable: false),
                    OffenderReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourtDates = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CourtLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bail = table.Column<bool>(type: "bit", nullable: false),
                    BailConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BailBreached = table.Column<bool>(type: "bit", nullable: false),
                    RequiredToBeArrested = table.Column<bool>(type: "bit", nullable: false),
                    WantedToArrest = table.Column<bool>(type: "bit", nullable: false),
                    OfficerInChargeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficerInChargeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficerInChargePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VictimUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
