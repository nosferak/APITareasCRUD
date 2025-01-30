using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.Entities;
using TareasCRUD.Core.Views;
using TareasCRUD.Infrastructure.Data.Configurations;

namespace TareasCRUD.Infrastructure.Data
{
    //internal class AppDbContext
    //{
    //}

    public class AppDbContext : DbContext
    {
        public DbSet<Estados> Estados { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
        //public DbSet<Usuarios> Usuarios { get; set; }


        //implementamos Vista con las tareas generadas
        public DbSet<V_Estados> V_Estados { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EstadosConfiguration());
            builder.ApplyConfiguration(new TareasConfiguration());
            //builder.ApplyConfiguration(new UsuariosConfiguration());

            builder
                    .Entity<V_Estados>()
                    .ToView(nameof(V_Estados))
                    .HasKey(t => t.IdTarea);
        }
    }
}
