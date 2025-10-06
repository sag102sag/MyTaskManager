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
    }
}
