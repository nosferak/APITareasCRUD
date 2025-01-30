using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasCRUD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateViewsEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW V_Estados AS
                SELECT 
                T.Id AS IdTarea,
                T.Nombre,
                T.Descripcion,
                T.Prioridad,
                T.FechaCreacion,
                T.FechaActualizacion,
                T.FechaVencimiento,
                E.Id As IdEstado,
                E.Nombre AS Estado
            FROM 
                Tareas T
            JOIN 
                Estados E ON T.IdEstado = E.Id;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS V_Estados;");
        }
    }
}
