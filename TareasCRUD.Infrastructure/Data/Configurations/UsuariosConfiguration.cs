using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.Entities;

namespace TareasCRUD.Infrastructure.Data.Configurations
{
    //internal class UsuariosConfiguration
    //{
    //}
    //public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios>
    //{
    //    public void Configure(EntityTypeBuilder<Usuarios> builder)
    //    {
    //        // Configuración de las propiedades
    //        builder
    //            .HasKey(u => u.Id); // Definir la clave primaria

    //        builder
    //            .Property(x => x.Id)
    //            .UseIdentityColumn();

    //        builder.Property(u => u.Email)
    //            .IsRequired()
    //            .HasMaxLength(100); // Aseguramos que 'Email' es requerido y tiene una longitud máxima

    //        builder.Property(u => u.Password)
    //            .IsRequired()
    //            .HasMaxLength(200); // Aseguramos que 'Password' es requerido y tiene una longitud máxima

    //        // Configuración de la relación con Tareas (1 a muchos)
    //        builder.HasMany(u => u.Tareas)
    //            .WithOne(t => t.Usuario)
    //            .HasForeignKey(t => t.IdUsuario)
    //            .OnDelete(DeleteBehavior.SetNull); // La eliminación de un Usuario no elimina sus Tareas, sino que pone en NULL la relación
          
    //        // Configuración de la tabla Usuarios
    //        builder.ToTable("Usuarios");
    //    }
    //}
}
