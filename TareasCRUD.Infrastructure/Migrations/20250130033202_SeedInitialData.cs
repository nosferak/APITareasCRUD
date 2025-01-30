using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasCRUD.Infrastructure.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insertar estados iniciales
            migrationBuilder.Sql("INSERT INTO Estados (Nombre) VALUES ('To Do');");
            migrationBuilder.Sql("INSERT INTO Estados (Nombre) VALUES ('In Progress');");
            migrationBuilder.Sql("INSERT INTO Estados (Nombre) VALUES ('Done');");

            // Insertar tareas de ejemplo
            migrationBuilder.Sql(@"
            INSERT INTO Tareas (Nombre, Descripcion, Prioridad, FechaCreacion, FechaVencimiento, IdEstado) 
            VALUES ('Configurar servidor', 'Instalar y configurar el servidor de producción', 'Alta', GETDATE(), DATEADD(DAY, 10, GETDATE()), (SELECT Id FROM Estados WHERE Nombre = 'To Do'));
        ");

            migrationBuilder.Sql(@"
            INSERT INTO Tareas (Nombre, Descripcion, Prioridad, FechaCreacion, FechaVencimiento, IdEstado) 
            VALUES ('Diseñar base de datos', 'Crear el modelo entidad-relación', 'Media', GETDATE(), DATEADD(DAY, 15, GETDATE()), (SELECT Id FROM Estados WHERE Nombre = 'In Progress'));
        ");

            migrationBuilder.Sql(@"
            INSERT INTO Tareas (Nombre, Descripcion, Prioridad, FechaCreacion, FechaVencimiento, IdEstado) 
            VALUES ('Desarrollar API', 'Implementar los servicios REST', 'Alta', GETDATE(), DATEADD(DAY, 30, GETDATE()), (SELECT Id FROM Estados WHERE Nombre = 'Done'));
        ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar tareas primero (por la relación con Estados)
            migrationBuilder.Sql("DELETE FROM Tareas;");

            // Eliminar estados
            migrationBuilder.Sql("DELETE FROM Estados WHERE Nombre IN ('To Do', 'In Progress', 'Done');");
        }
    }

}
