using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasCRUD.Core.Views
{
    //internal class V_Estadisticas
    //{
    //}
    public class V_Estados
    {
        public int IdTarea { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Prioridad { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
       
    }
}
