using System;
namespace WebApi;

public enum EstadoTarea
{
    Pendiente,
    Progreso,
    Completada
}

public class Tarea
{
    //Campos
    private int id;
    private string titulo;
    private string descripcion;
    private EstadoTarea estado;

    //Propiedades
    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }

}