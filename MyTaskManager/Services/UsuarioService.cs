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
    public class UsuarioService: GenericService<Usuario>
    {
        public UsuarioService(AppDbContext context) : base(context)
        {
            
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
