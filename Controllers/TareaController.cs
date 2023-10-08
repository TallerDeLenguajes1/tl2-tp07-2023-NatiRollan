using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class TareaController : ControllerBase
{
    private ManejoDeTarea manejoDeTarea;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        AccesoADatos accesoADatos = new AccesoADatos();
        manejoDeTarea = new ManejoDeTarea(accesoADatos);
    }

    [HttpPost("AddTarea")]
    public ActionResult<Tarea> AddTarea(Tarea tareaNueva)
    {
        Tarea tarea = manejoDeTarea.AgregarTarea(tareaNueva);
        if (tarea != null)
        {
            return Ok(tarea);
        } else
        {
            return BadRequest();
        }
    }

    [HttpGet("GetTarea")]
    public ActionResult<Tarea> GetTarea(int idTarea)
    {
        Tarea tareaEncontrada = manejoDeTarea.ObtenerTarea(idTarea);
        if (tareaEncontrada != null)
        {
            return Ok(tareaEncontrada);
        } else
        {
            return NotFound("Tarea no encontrada");
        }
    }

    [HttpPut("ActualizarTarea")]
    public ActionResult<Tarea> ActualizarTarea(int idTarea, int estado)
    {
        Tarea tareaActualizada = manejoDeTarea.ActualizarTarea(idTarea, estado);
        if (tareaActualizada != null)
        {
            return Ok(tareaActualizada);
        } else
        {
            return BadRequest();
        }
    }

    [HttpDelete("BorrarTarea")]
    public ActionResult BorrarTarea(int idTarea)
    {
        bool control = manejoDeTarea.BorrarTarea(idTarea);
        if (control)
        {
            return Ok();
        } else
        {
            return NotFound("Tarea no encontrada");
        }
    }

    [HttpGet("GetTareas")]
    public ActionResult<List<Tarea>> GetTareas()
    {
        List<Tarea> tareas = manejoDeTarea.GetTareas();
        if (tareas != null)
        {
            return Ok(tareas);
        } else
        {
            return NotFound();
        }
    }

    [HttpGet("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        List<Tarea> tareas = manejoDeTarea.GetTareasCompletas();
        if (tareas != null)
        {
            return Ok(tareas);
        } else
        {
            return NotFound();
        }
    }
}