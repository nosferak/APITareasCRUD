using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TareasCRUD.Core.Entities;

namespace TareasCRUD.Infrastructure.Data.Configurations
{
    //internal class TareasConfiguration
    //{
    //}

    public class TareasConfiguration : IEntityTypeConfiguration<Tareas>
    {
        public void Configure(EntityTypeBuilder<Tareas> builder)
        {        
            // Configuración de las propiedades
            builder.
                HasKey(t => t.Id); // Definir la clave primaria

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(t => t.Nombre)
                .IsRequired()
                .HasMaxLength(100); // Aseguramos que 'Nombre' es requerido y tiene una longitud máxima

            builder.Property(t => t.Descripcion)
                .IsRequired()
                .HasMaxLength(500); // Aseguramos que 'Descripcion' es requerido y tiene una longitud máxima

            builder.Property(t => t.Prioridad)
                .IsRequired()
                .HasMaxLength(20); // Aseguramos que 'Prioridad' es requerido y tiene una longitud máxima

            builder.Property(t => t.FechaCreacion)
                .IsRequired();

            builder.Property(t => t.FechaActualizacion)
                .IsRequired(false);

            builder.Property(t => t.FechaVencimiento)
                .IsRequired(false); // La fecha de vencimiento puede ser nula

            // Configuración de las relaciones
            builder.HasOne(t => t.Estado)
                .WithMany(e => e.Tareas)
                .HasForeignKey(t => t.IdEstado)
                .OnDelete(DeleteBehavior.Restrict); // Establecer la relación con la tabla Estados

            //builder.HasOne(t => t.Usuario)
            //    .WithMany(u => u.Tareas)
            //    .HasForeignKey(t => t.IdUsuario)
            //    .OnDelete(DeleteBehavior.SetNull); // Establecer la relación con la tabla Usuarios, permitiendo valores nulos
            
            // Configuración de la tabla Tareas
            builder.ToTable("Tareas");
        }
    }
}
