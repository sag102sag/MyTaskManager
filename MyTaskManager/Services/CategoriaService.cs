using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTaskManager.Data;
using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public class CategoriaService : GenericService<Categoria>
    {
        public CategoriaService(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            var categoria = await _context.Categorias.Include(c => c.Tareas).FirstOrDefaultAsync(c=> c.Id == id);

            if (categoria == null) throw new Exception("Categoría no encontrada");
            if (categoria.Tareas.Any()) throw new InvalidOperationException("No se puede eliminar la categoría ya que tiene tareas asociadas.");

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }
}
