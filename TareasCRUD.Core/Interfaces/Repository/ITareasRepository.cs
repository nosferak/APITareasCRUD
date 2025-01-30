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
        //ValueTask<V_Estados> GetTareasByIdEstado(int Id);
        Task<List<V_Estados>> GetTareasByIdEstado(int Id);
        Task<IEnumerable<V_Estados>> GetAllTareasEstado();
        Task<IEnumerable<V_Tareas>> GetEstadisticasTareasEstado();


        // Función para guardar un archivo PDF (si es necesario)
        //Task<string> GuardarArchivoPdfAsync(byte[] archivoPdf, string nombreArchivo);
    }
}
