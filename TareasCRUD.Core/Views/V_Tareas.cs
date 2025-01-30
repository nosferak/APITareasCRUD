using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasCRUD.Core.Views
{
    //internal class V_Tareas
    //{
    //}
    public class V_Tareas
    {        
        public int IdEstado { get; set; }

        public string NombreEstado { get; set; }

        public int CantidadTareas { get; set; }
    }
}
