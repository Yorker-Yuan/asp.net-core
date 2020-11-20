using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JQueryAjaxCRUDInCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    fTranId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fAccountNum = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    fBeneficiaryName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    fBankName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    fSwiftCode = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    fAmount = table.Column<int>(nullable: false),
                    fDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.fTranId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
