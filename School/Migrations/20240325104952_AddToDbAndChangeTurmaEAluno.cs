using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace School.Migrations
{
    /// <inheritdoc />
    public partial class AddToDbAndChangeTurmaEAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Alunos_AlunoId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_AlunoId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Turmas");

            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1,
                column: "TurmaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 2,
                column: "TurmaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 3,
                column: "TurmaId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "Ano", "Nome" },
                values: new object[,]
                {
                    { 1, 7, "A" },
                    { 2, 4, "B" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos");

            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_AlunoId",
                table: "Turmas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Alunos_AlunoId",
                table: "Turmas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
