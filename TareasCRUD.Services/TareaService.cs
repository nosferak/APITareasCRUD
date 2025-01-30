using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TareasCRUD.Core.DTOs;
using TareasCRUD.Core.Entities;
using TareasCRUD.Core.Interfaces;
using TareasCRUD.Core.Interfaces.Services;
using TareasCRUD.Core.Views;
using TareasCRUD.Services.Validators;

namespace TareasCRUD.Service
{
    //internal class TareaService
    //{
    //}

    public class TareaService : ITareasService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TareaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    
        public async Task<DTOCreateTareaResponse> CreateTarea(DTOCreateTareaRequest newTarea)
        {
            
            TareaValidator validator = new();

            // Construcción de la entidad Tareas a partir del DTO de entrada
            Tareas tarea = new Tareas
            {                
                Nombre = newTarea.Nombre,
                Descripcion = newTarea.Descripcion,
                Prioridad = newTarea.Prioridad,
                IdEstado = newTarea.IdEstado,
                //IdUsuario = newTarea.IdUsuario,
                FechaCreacion = DateTime.Now,
                FechaVencimiento = newTarea.FechaVencimiento
                //ArchivoPDF = newTarea.ArchivoPDF
            };

            DTOCreateTareaResponse TareaResult = new DTOCreateTareaResponse();

            // Validación de la entidad Tareas
            var validationResult = await validator.ValidateAsync(tarea);

            if (string.IsNullOrEmpty(tarea.Nombre))
            {
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure
                {
                    PropertyName = "Nombre",
                    ErrorMessage = "El nombre de la tarea es obligatorio."
                });
            }

            if (validationResult.IsValid)
            {
                // Guardamos la tarea en la base de datos
                await _unitOfWork.TareasRepository.AddAsync(tarea);
                await _unitOfWork.CommitAsync();

                // Respuesta en caso de éxito
                TareaResult = new DTOCreateTareaResponse
                {
                    IdTarea = tarea.Id,
                    Message = "Tarea creada con éxito."
                };
            }
            else
            {
                // Si hay errores, tomamos el primero y lo devolvemos en la respuesta
                var propertyName = JsonSerializer.Serialize(validationResult.Errors[0].PropertyName);
                var errorMessage = JsonSerializer.Serialize(validationResult.Errors[0].ErrorMessage);

                TareaResult = new DTOCreateTareaResponse
                {
                    IdTarea = 0,
                    Message = $"ErrorMessage: {errorMessage} - PropertyName: {propertyName}".Replace("\\\"", "")
                };

                return TareaResult;
            }

            return TareaResult;
        }
    
        public async Task<DTOUpdateTareaResponse> UpdateTarea(DTOUpdateTareaRequest newTareaValues)
        {
            int TareaToBeUpdatedId = newTareaValues.Id;
            Tareas tareaToBeUpdated = await _unitOfWork.TareasRepository.GetByIdAsync(TareaToBeUpdatedId);

            DTOUpdateTareaResponse TareaResult = new DTOUpdateTareaResponse();

            if (tareaToBeUpdated == null)
            {
                TareaResult = new DTOUpdateTareaResponse
                {
                    IdTarea = TareaToBeUpdatedId,
                    Message = $"La tarea Id {TareaToBeUpdatedId} no existe"
                };

                return TareaResult;
            }
            else
            {
                tareaToBeUpdated.IdEstado = newTareaValues.IdEstado; //modifica el estado de la orden
                //tareaToBeUpdated.IdUsuario = newTareaValues.IdUsuario; //modifica el estado de la orden
                tareaToBeUpdated.Nombre = newTareaValues.Nombre; //modifica el estado de la orden
                tareaToBeUpdated.Descripcion = newTareaValues.Descripcion; //modifica el estado de la orden
                tareaToBeUpdated.Prioridad = newTareaValues.Prioridad; //modifica el estado de la orden
                tareaToBeUpdated.FechaActualizacion = DateTime.Now; //modifica el estado de la orden
                tareaToBeUpdated.FechaVencimiento = newTareaValues.FechaVencimiento; //modifica el estado de la orden

                TareaValidator validator = new();
                var validationResult = await validator.ValidateAsync(tareaToBeUpdated);

                if (validationResult.IsValid)
                {
                    await _unitOfWork.TareasRepository.Update(tareaToBeUpdated);
                    await _unitOfWork.CommitAsync();

                    TareaResult = new DTOUpdateTareaResponse
                    {
                        IdTarea = TareaToBeUpdatedId,
                        Message = $"La tarea Id {TareaToBeUpdatedId} fue actualizado con exito"
                    };
                }
                else
                {
                    var PropertyName = JsonSerializer.Serialize(validationResult.Errors[0].PropertyName);
                    var ErrorMessage = JsonSerializer.Serialize(validationResult.Errors[0].ErrorMessage);

                    TareaResult = new DTOUpdateTareaResponse
                    {
                        IdTarea = 0,
                        Message = $"ErrorMessage: {ErrorMessage} - PropertyName: {PropertyName}".Replace("\\\"", "")
                    };

                    return TareaResult;
                }

                return TareaResult;
            }
        }

        public async Task DeleteTarea(int tareaId)
        {
            var tarea = await _unitOfWork.TareasRepository.GetByIdAsync(tareaId);
            if (tarea == null)
            {
                throw new KeyNotFoundException($"No se encontró la tarea con ID {tareaId}.");
            }

            _unitOfWork.TareasRepository.Remove(tarea);
            await _unitOfWork.CommitAsync();
        }

        public async Task<V_Estados> GetTareasByIdEstado(int id)
        {
            return await _unitOfWork.TareasRepository.GetTareasByIdEstado(id)
                   ?? throw new KeyNotFoundException($"No se encontraron tareas con el estado ID {id}.");
        }

        public async Task<IEnumerable<V_Estados>> GetAllTareasEstado()
        {
            return await _unitOfWork.TareasRepository.GetAllTareasEstado();
        }
    }
}
