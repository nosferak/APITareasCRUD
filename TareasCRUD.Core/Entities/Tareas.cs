using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasCRUD.Core.Entities
{
    //internal class Tareas
    //{
    //}
    public class Tareas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; } // "Baja", "Media", "Alta"
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public byte[] ArchivoPDF { get; set; }  //Almacenamos el archivo PDF como un arreglo de bytes

        // Relación con Estado
        public int IdEstado { get; set; }
        public Estados Estado { get; set; }

        // Relación con Usuario
        //public int? IdUsuario { get; set; }
        //public Usuarios Usuario { get; set; }
    }
}
