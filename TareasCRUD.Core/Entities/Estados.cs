using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TareasCRUD.Core.Entities
{
    //internal class Estado
    //{
    //}
    public class Estados
    {
        public Estados()
        {
            Tareas = new Collection<Tareas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        //Relación con Tareas
        public ICollection<Tareas> Tareas { get; set; }
    }
}
