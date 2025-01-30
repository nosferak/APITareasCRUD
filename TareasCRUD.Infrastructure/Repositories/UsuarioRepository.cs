using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.Entities;
using TareasCRUD.Core.Interfaces.Repository;
using TareasCRUD.Infrastructure.Data;

namespace TareasCRUD.Infrastructure.Repositories
{
    //internal class UsuarioRepository
    //{
    //}

    //public class UsuarioRepository : BaseRepository<Usuarios>, IUsuarioRepository
    //{
    //    public UsuarioRepository(AppDbContext context) : base(context)
    //    {

    //    }

    //    // Método para validar las credenciales del usuario en la base de datos
    //    public async Task<bool> ValidarUsuarioAsync(string email, string password)
    //    {
    //        // Buscamos el usuario por su email
    //        var usuario = await Context.Usuarios
    //                                   .Where(u => u.Email == email)
    //                                   .FirstOrDefaultAsync();

    //        // Si el usuario no existe
    //        if (usuario == null)
    //        {
    //            return false;
    //        }

    //        // Comprobamos si el password es válido
    //        // Aquí asumimos que el password almacenado en la base de datos está hasheado
    //        return VerificarPassword(password, usuario.Password);
    //    }

    //    // Método que verifica si el password es correcto, comparando el hash
    //    private bool VerificarPassword(string password, string hashedPassword)
    //    {
    //        // Suponiendo que se usa un hash SHA256 (ajustar según el algoritmo utilizado)
    //        // Si usas BCrypt o alguna librería específica, necesitarás esa validación en lugar de SHA256
    //        using (var sha256 = SHA256.Create())
    //        {
    //            var computedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    //            var computedPassword = Convert.ToBase64String(computedHash);
    //            return computedPassword == hashedPassword;
    //        }
    //    }
    //}
}

