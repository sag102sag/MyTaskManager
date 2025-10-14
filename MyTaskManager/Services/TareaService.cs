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
    public class TareaService : GenericService<Tarea>
    {
        public TareaService(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Tarea>> GetByTituloAsync(string titulo)
        {
            return await _context.Tareas.Where(t => t.Titulo.Contains(titulo)).ToListAsync();
        }

        public async Task<Tarea> GetByIdAsync(int id)
        {
            return await _context.Tareas
                .Include(t => t.Usuario)
                .Include(t => t.Categoria)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarea>> GetAllAsync()
        {
            return await _context.Tareas
                .Include(t => t.Categoria)
                .Include(t => t.Usuario)
                .ToListAsync();
        }
    }
}
