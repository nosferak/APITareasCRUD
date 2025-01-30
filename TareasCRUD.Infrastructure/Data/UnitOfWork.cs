using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.Interfaces;
using TareasCRUD.Core.Interfaces.Repository;
using TareasCRUD.Infrastructure.Repositories;

namespace TareasCRUD.Infrastructure.Data
{
    //internal class UnitOfWork
    //{
    //}

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private TareaRepository _tareaRepository;
        //private UsuarioRepository _usuarioRepository;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public ITareasRepository TareasRepository => _tareaRepository ??= new TareaRepository(_context);

        //public IUsuarioRepository UsuarioRepository => _usuarioRepository ??= new UsuarioRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
