using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoService.Infrastructure.Migrations.TodoRead
{
    /// <inheritdoc />
    public partial class AddSpaceSummaryAndTodoSummaryEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "spaceSummaries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_spaceSummaries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "todoSummaries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    spaceId = table.Column<Guid>(type: "uuid", nullable: true),
                    parentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_todoSummaries", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spaceSummaries");

            migrationBuilder.DropTable(
                name: "todoSummaries");
        }
    }
}
