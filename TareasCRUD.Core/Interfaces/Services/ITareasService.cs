using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.DTOs;
using TareasCRUD.Core.Views;

namespace TareasCRUD.Core.Interfaces.Services
{
    //internal class ITareasService
    //{
    //}
    public interface ITareasService
    {
        Task<DTOCreateTareaResponse> CreateTarea(DTOCreateTareaRequest newTarea);
        Task<DTOUpdateTareaResponse> UpdateTarea(DTOUpdateTareaRequest newTareaValues);
        Task DeleteTarea(int TareaId);
        Task<V_Estados> GetTareasByIdEstado(int id);
        Task<IEnumerable<V_Estados>> GetAllTareasEstado();
    }
}
