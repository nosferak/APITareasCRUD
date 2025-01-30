using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TareasCRUD.Core.DTOs;
using TareasCRUD.Core.Interfaces.Services;
using TareasCRUD.Core.Views;
using TareasCRUD.Service;

namespace TareasCRUD.WebApi.Controllers
{
    //public class TareasController
    //{
    //}
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        //Aplicamos inyeccion de dependencias / AutoMapper Injection
        private readonly ITareasService _TareaService;
        private readonly IMapper _Mapper;

        public TareasController(ITareasService TareaService, IMapper mapper)
        {
            _TareaService = TareaService;
            _Mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<V_Estados>> GetTareasByIdEstado(int id)
        {
            var tarea = await _TareaService.GetTareasByIdEstado(id);
            if (tarea == null)
            {
                return NotFound($"No se encontró una tarea con el estado ID {id}");
            }
            return Ok(tarea);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<V_Estados>>> GetAllTareasEstado()
        {
            var tareas = await _TareaService.GetAllTareasEstado();
            return Ok(tareas);
        }

        [HttpPost]
        public async Task<ActionResult<DTOCreateTareaResponse>> CreateTarea([FromBody] DTOCreateTareaRequest newTarea)
        {
            try
            {
                var createdTarea = await _TareaService.CreateTarea(newTarea);
                return Ok(createdTarea);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<DTOUpdateTareaResponse>> UpdateTarea([FromBody] DTOUpdateTareaRequest newTareaValues)
        {
            try
            {
                var updatedTarea = await _TareaService.UpdateTarea(newTareaValues);
                return Ok(updatedTarea);
            }
            catch
            {
                return StatusCode(500, "Error al intentar modificar la tarea");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTarea(int id)
        {
            try
            {
                await _TareaService.DeleteTarea(id);
                return Ok(new { message = $"La tarea con ID {id} fue eliminada con éxito" });
            }
            catch
            {
                return StatusCode(500, "La tarea no pudo ser eliminada o ya fue eliminada previamente");
            }
        }
    }
}

