using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasCRUD.Core.DTOs
{
    public class DTOCreateTareaRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }  // "Baja", "Media", "Alta"
        public DateTime? FechaVencimiento { get; set; }
        public int IdEstado { get; set; }  // Asociado a Estado
        public IFormFile ArchivoPDF { get; set; } // Para recibir el archivo PDF

        //public int? IdUsuario { get; set; }  // Opcional
    }
}
