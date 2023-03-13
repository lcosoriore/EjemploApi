﻿using System.Text.Json.Serialization;
using System.Threading;

namespace EjemploApi.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Peso { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
