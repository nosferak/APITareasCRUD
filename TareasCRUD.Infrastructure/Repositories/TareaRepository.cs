using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.Entities;
using TareasCRUD.Core.Interfaces.Repository;
using TareasCRUD.Core.Views;
using TareasCRUD.Infrastructure.Data;

namespace TareasCRUD.Infrastructure.Repositories
{
    //internal class TareaRepository
    //{
    //}

    public class TareaRepository : BaseRepository<Tareas>, ITareasRepository
    {
        public TareaRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<V_Estados>> GetAllTareasEstado()
        {
            return await Context.V_Estados.ToListAsync();

        }
        public async ValueTask<V_Estados> GetTareasByIdEstado(int Id)
        {
            return await Context.V_Estados.FindAsync(Id);
        }
    }
}
