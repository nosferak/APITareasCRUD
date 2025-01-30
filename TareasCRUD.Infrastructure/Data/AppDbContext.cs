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

        //implementamos Vistas
        public DbSet<V_Estados> V_Estados { get; set; }
        public DbSet<V_Tareas> V_Tareas { get; set; }

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

            builder
                    .Entity<V_Tareas>()
                    //.ToView("V_Tareas")
                    .ToView(nameof(V_Tareas))
                    .HasKey(t => t.IdEstado);
        }
    }
}
