using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DCandidates",
                columns: table => new
                {
                    fID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fFullName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    fMobile = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    fEmail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    fAge = table.Column<int>(nullable: false),
                    fBloodGroup = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    fAddress = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCandidates", x => x.fID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCandidates");
        }
    }
}
