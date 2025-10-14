using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager.Models
{
    public class Usuario: IClonable<Usuario>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public ICollection<Tarea> Tareas { get; set; }

        public Usuario Clonar()
        {
            return new Usuario
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Email = this.Email,
                Tareas = this.Tareas // Referencia a las mismas tareas (no es problema)
            };
        }
    }
}
