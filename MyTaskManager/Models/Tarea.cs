using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager.Models
{
    public class Tarea: IClonable<Tarea>
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "El usuario es obligatorio")]
        public Usuario Usuario { get; set; }

        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public Categoria Categoria { get; set; }

        public Tarea Clonar()
        {
            return new Tarea
            {
                Id = this.Id,
                Titulo = this.Titulo,
                Descripcion = this.Descripcion,
                FechaCreacion = this.FechaCreacion,
                UsuarioId = this.UsuarioId,
                Usuario = this.Usuario, // Referencia al mismo usuario (no es problema)
                CategoriaId = this.CategoriaId,
                Categoria = this.Categoria // Referencia a la misma categoría (no es problema)
            };
        }
    }
}
