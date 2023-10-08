using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
namespace WebApi;

public class AccesoADatos
{
    private string ruta = "tareas.json";
    public List<Tarea> Obtener()
    {
        List<Tarea> ListadoTareas = new List<Tarea>();
        if (File.Exists(ruta))
        {
            string jsonString = File.ReadAllText(ruta);
            ListadoTareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
        } else
        {
            Console.WriteLine("El archivo json no existe");
        }
        return ListadoTareas;
    }

    public void Guardar(List<Tarea> tarea)
    {
        string listadoTareasJson = JsonSerializer.Serialize(tarea);
        File.WriteAllText("tareas.json", listadoTareasJson);
    }
}