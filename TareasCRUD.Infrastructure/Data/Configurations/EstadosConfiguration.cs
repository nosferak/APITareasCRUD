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
    //internal class EstadosConfiguration
    //{
    //}
    public class EstadosConfiguration : IEntityTypeConfiguration<Estados>
    {
        public void Configure(EntityTypeBuilder<Estados> builder)
        {
            // Configuración de las propiedades
            builder
                .HasKey(e => e.Id); // Definir la clave primaria

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50); // Aseguramos que 'Nombre' es requerido y tiene una longitud máxima

            // Configuración de la relación con Tareas (1 a muchos)
            builder.HasMany(e => e.Tareas)
                .WithOne(t => t.Estado)
                .HasForeignKey(t => t.IdEstado)
                .OnDelete(DeleteBehavior.Cascade); // La eliminación de un Estado también elimina sus Tareas
        
            // Configuración de la tabla Estados
            builder.ToTable("Estados");
        }
    }
}
