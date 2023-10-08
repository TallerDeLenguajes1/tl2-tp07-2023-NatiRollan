using System;
using System.Collections.Generic;
namespace WebApi;

public class ManejoDeTarea
{
    //Campos
    private AccesoADatos accesoADatos;

    //Constructor
    public ManejoDeTarea(AccesoADatos accesoADatos)
    {
        this.accesoADatos = accesoADatos;
    }

    //Metodos
    public Tarea AgregarTarea(Tarea tarea)
    {
        List<Tarea> ListadoTareas = accesoADatos.Obtener();
        Tarea ultimaTarea = ListadoTareas.Last();
        tarea.Id = ultimaTarea.Id +1;
        ListadoTareas.Add(tarea);
        accesoADatos.Guardar(ListadoTareas);
        return tarea;
    }

    public Tarea ObtenerTarea(int idTarea)
    {
        List<Tarea> ListadoTareas = accesoADatos.Obtener();
        Tarea tareaBuscada = ListadoTareas.FirstOrDefault(tarea => tarea.Id == idTarea);
        if (tareaBuscada != null)
        {
            return tareaBuscada;
        } else
        {
            return null;
        }
    }

    public Tarea ActualizarTarea(int idTarea, int estado)
    {
        List<Tarea> ListadoTarea = accesoADatos.Obtener();
        Tarea tareaBuscada = ListadoTarea.FirstOrDefault(tarea => tarea.Id == idTarea);
        if (tareaBuscada != null)
        {
            if (estado == 1)
            {
                tareaBuscada.Estado = EstadoTarea.Progreso;
                accesoADatos.Guardar(ListadoTarea);
                return tareaBuscada;
            }
            else
            {
                tareaBuscada.Estado = EstadoTarea.Completada;
                accesoADatos.Guardar(ListadoTarea);
                return tareaBuscada;
            }         
        } else
        {
            return null;
        }
    }

    public bool BorrarTarea(int idTarea)
    {
        List<Tarea> ListadoTarea = accesoADatos.Obtener();
        Tarea tareaBuscada = ListadoTarea.FirstOrDefault(tarea => tarea.Id == idTarea);
        if (tareaBuscada != null)
        {
            ListadoTarea.Remove(tareaBuscada);
            accesoADatos.Guardar(ListadoTarea);
            return true;
        } else
        {
            return false;
        }
    }

    public List<Tarea> GetTareas()
    {
        return accesoADatos.Obtener();
    }

    public List<Tarea> GetTareasCompletas()
    {
        List<Tarea> ListadoTarea = accesoADatos.Obtener();
        List<Tarea> tareasCompletas = ListadoTarea.Where(tarea => tarea.Estado == EstadoTarea.Completada).ToList();
        if (tareasCompletas != null)
        {
            return tareasCompletas;
        } else
        {
            return null;
        }
    }
}