using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareasCRUD.Core.DTOs
{

    public class DTOCreateTareaResponse
    {
        public string Message { get; set; }
        public int IdTarea { get; set; }
    }

}
