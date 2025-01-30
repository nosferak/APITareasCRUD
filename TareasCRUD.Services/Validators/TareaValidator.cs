using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TareasCRUD.Core.Entities;

namespace TareasCRUD.Services.Validators
{
    public class TareaValidator : AbstractValidator<Tareas>
    {
        public TareaValidator()
        {

            RuleFor(t => t.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");

            RuleFor(t => t.Prioridad)
                .NotEmpty().WithMessage("La prioridad es obligatoria.")
                .Must(p => new[] { "Baja", "Media", "Alta" }.Contains(p))
                .WithMessage("La prioridad debe ser 'Baja', 'Media' o 'Alta'.");

            //RuleFor(t => t.FechaCreacion)
            //    .NotEmpty().WithMessage("La fecha de creación es obligatoria.")
            //    .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de creación no puede ser en el futuro.");

            RuleFor(t => t.FechaVencimiento)
                .GreaterThan(t => t.FechaCreacion)
                .When(t => t.FechaVencimiento.HasValue)
                .WithMessage("La fecha de vencimiento debe ser mayor que la fecha de creación.");

            RuleFor(t => t.IdEstado)
                .GreaterThan(0).WithMessage("El IdEstado debe ser un número diferente a 0.");

            //RuleFor(t => t.IdUsuario)
            //    .GreaterThan(0).WithMessage("El IdUsuario debe ser diferente de 0 y debe existir");
           
            //RuleFor(t => t.IdUsuario)
            //    .GreaterThan(0).When(t => t.IdUsuario.HasValue)
            //    .WithMessage("El IdUsuario debe ser un número mayor a 0 si se proporciona.");
        }
    }
}
