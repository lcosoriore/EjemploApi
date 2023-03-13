using EjemploApi.Interfaces;
using EjemploApi.Models;

namespace EjemploApi.Services
{
    public class TareaService: ITareaService
    {
        TareasContext context;
        public TareaService(TareasContext tareasContext) 
        {
            context = tareasContext;
        }
        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            context.Add(tarea);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            var tareaActual = context.Tareas.Find(id);
            if (tareaActual != null)
            {
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.Resumen = tarea.Resumen;
                tareaActual.FechaCreacion =DateTime.Now;
                tareaActual.CategoriaId= tarea.CategoriaId;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                await context.SaveChangesAsync();
            }

        }

        public async Task Delete(Guid id)
        {
            var tareaActual = context.Tareas.Find(id);
            if (tareaActual != null)
            {
                context.Remove(tareaActual);
                await context.SaveChangesAsync();
            }

        }
    }
}
