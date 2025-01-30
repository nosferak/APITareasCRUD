using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.Interfaces.Repository;

namespace TareasCRUD.Core.Interfaces
{
    //internal class IUnitOfWork
    //{
    //}

    public interface IUnitOfWork : IDisposable
    {
        ITareasRepository TareasRepository { get; }
        //IUsuarioRepository UsuarioRepository { get; }

        Task<int> CommitAsync();
    }
}
