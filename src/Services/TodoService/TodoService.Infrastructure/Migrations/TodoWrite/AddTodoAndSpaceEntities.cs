#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoService.Infrastructure.Migrations.TodoWrite
{
    /// <inheritdoc />
    public partial class AddTodoAndSpaceEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "space",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_space", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "todo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    spaceId = table.Column<Guid>(type: "uuid", nullable: true),
                    parentId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsImportantTodo = table.Column<bool>(type: "boolean", nullable: false),
                    IsUrgentTodo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pK_todo", x => x.id);
                    table.ForeignKey(
                        name: "fK_todo_space_spaceId",
                        column: x => x.spaceId,
                        principalTable: "space",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fK_todo_todo_parentId",
                        column: x => x.parentId,
                        principalTable: "todo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "iX_todo_parentId",
                table: "todo",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "iX_todo_spaceId",
                table: "todo",
                column: "spaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todo");

            migrationBuilder.DropTable(
                name: "space");
        }
    }
}
