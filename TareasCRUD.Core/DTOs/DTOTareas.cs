using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasCRUD.Core.DTOs
{
    //internal class DTOTareas
    //{
    //}
    public class DTOCreateTareaRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }  // "Baja", "Media", "Alta"
        public DateTime? FechaVencimiento { get; set; }
        public int IdEstado { get; set; }  // Asociado a Estado
        public int? IdUsuario { get; set; }  // Opcional
    }

    public class DTOCreateTareaResponse
    {
        public string Message { get; set; }
        public int IdTarea { get; set; }
    }

    public class DTOUpdateTareaRequest
    {
        public int Id { get; set; }       
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }  // "Baja", "Media", "Alta"
        public int IdEstado { get; set; }  // Asociado a Estado
        public DateTime? FechaVencimiento { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public int? IdUsuario { get; set; }  // Opcional
    }

    public class DTOUpdateTareaResponse
    {
        public string Message { get; set; }
        public int IdTarea { get; set; }
    }
}
