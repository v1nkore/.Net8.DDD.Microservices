#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoService.Infrastructure.Migrations.TodoWrite
{
    /// <inheritdoc />
    public partial class FixEisenhowerMatrixComplexTypeNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsUrgentTodo",
                table: "todo",
                newName: "is_urgent");

            migrationBuilder.RenameColumn(
                name: "IsImportantTodo",
                table: "todo",
                newName: "is_important");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_urgent",
                table: "todo",
                newName: "IsUrgentTodo");

            migrationBuilder.RenameColumn(
                name: "is_important",
                table: "todo",
                newName: "IsImportantTodo");
        }
    }
}
