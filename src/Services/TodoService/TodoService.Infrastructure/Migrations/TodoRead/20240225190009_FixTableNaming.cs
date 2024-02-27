using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoService.Infrastructure.Migrations.TodoRead
{
    /// <inheritdoc />
    public partial class FixTableNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pK_todoSummaries",
                table: "todoSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "pK_spaceSummaries",
                table: "spaceSummaries");

            migrationBuilder.RenameTable(
                name: "todoSummaries",
                newName: "todo_summary");

            migrationBuilder.RenameTable(
                name: "spaceSummaries",
                newName: "table_summary");

            migrationBuilder.AddPrimaryKey(
                name: "pK_todo_summary",
                table: "todo_summary",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pK_table_summary",
                table: "table_summary",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pK_todo_summary",
                table: "todo_summary");

            migrationBuilder.DropPrimaryKey(
                name: "pK_table_summary",
                table: "table_summary");

            migrationBuilder.RenameTable(
                name: "todo_summary",
                newName: "todoSummaries");

            migrationBuilder.RenameTable(
                name: "table_summary",
                newName: "spaceSummaries");

            migrationBuilder.AddPrimaryKey(
                name: "pK_todoSummaries",
                table: "todoSummaries",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pK_spaceSummaries",
                table: "spaceSummaries",
                column: "id");
        }
    }
}
