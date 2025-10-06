using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTaskManager.Models;

namespace MyTaskManager.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // Constructor vacío para las migraciones
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=TaskManagerDB;user=root;password=mysql", new MySqlServerVersion(new Version(8, 0, 42)));
            }
        }
    }
}
