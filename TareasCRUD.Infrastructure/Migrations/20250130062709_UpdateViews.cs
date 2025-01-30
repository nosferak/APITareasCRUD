using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasCRUD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"        
            CREATE VIEW V_Estados AS
            SELECT 
                T.Id AS IdTarea,
                T.Nombre,
                T.Descripcion,
                T.Prioridad,
                T.FechaCreacion,
                T.FechaActualizacion,
                T.FechaVencimiento,
                E.Nombre AS Estado
            FROM 
                Tareas T
            JOIN 
                Estados E ON T.IdEstado = E.Id;
            ");

            migrationBuilder.Sql(@"
            CREATE VIEW V_Tareas AS
            SELECT 
                E.Id as IdEstado, 
                E.Nombre as NombreEstado, 
                COUNT(T.Id) AS CantidadTareas
            FROM 
                Estados E
            LEFT JOIN 
                Tareas T ON T.IdEstado = E.Id
            GROUP BY 
                E.Id, E.Nombre;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS V_Estados;");

            migrationBuilder.Sql("DROP VIEW IF EXISTS V_Tareas;");
        }
    }
}
