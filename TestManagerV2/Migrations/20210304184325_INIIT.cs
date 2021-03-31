using Microsoft.EntityFrameworkCore.Migrations;

namespace TestManagerV2.Migrations
{
    public partial class INIIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(maxLength: 60, nullable: false),
                    TestDescription = table.Column<string>(maxLength: 255, nullable: false),
                    CircuitName = table.Column<string>(maxLength: 60, nullable: false),
                    CircuitId = table.Column<int>(nullable: false),
                    Environment = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestId);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    StepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Action = table.Column<string>(maxLength: 60, nullable: false),
                    ElementIdentifier = table.Column<string>(maxLength: 60, nullable: false),
                    ElementIdentifierType = table.Column<string>(maxLength: 60, nullable: false),
                    Data = table.Column<string>(maxLength: 60, nullable: false),
                    ElementIndex = table.Column<int>(nullable: false),
                    ErrorDescription = table.Column<string>(maxLength: 255, nullable: false),
                    StepNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.StepId);
                    table.ForeignKey(
                        name: "FK_Step_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Step_TestId",
                table: "Step",
                column: "TestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
