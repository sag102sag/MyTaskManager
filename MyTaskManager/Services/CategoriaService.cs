using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTaskManager.Data;
using MyTaskManager.Models;

namespace MyTaskManager.Services
{
    public class CategoriaService : GenericService<Categoria>
    {
        public CategoriaService(AppDbContext context) : base(context)
        {
        }
    }
}
