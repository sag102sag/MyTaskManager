using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager.Models
{
    public class Categoria: IClonable<Categoria>
    {  
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public ICollection<Tarea> Tareas { get; set; }

        public Categoria Clonar()
        {
            return new Categoria
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Tareas = this.Tareas // Referencia a las mismas tareas (no es problema)
            };
        }
    }
}
