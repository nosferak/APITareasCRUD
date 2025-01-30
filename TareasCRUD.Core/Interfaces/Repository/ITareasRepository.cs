using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.Entities;
using TareasCRUD.Core.Views;

namespace TareasCRUD.Core.Interfaces.Repository
{
    //internal class ITareasRepository
    //{
    //}
    public interface ITareasRepository : IBaseRepository<Tareas>
    {
        Task<IEnumerable<V_Estados>> GetAllTareasEstado();
        ValueTask<V_Estados> GetTareasByIdEstado(int Id);

        // Función para guardar un archivo PDF (si es necesario)
        //Task<string> GuardarArchivoPdfAsync(byte[] archivoPdf, string nombreArchivo);
    }
}
