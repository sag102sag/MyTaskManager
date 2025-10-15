using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MyTaskManager.Data;
using MyTaskManager.Services;
using MyTaskManager.Views;

namespace MyTaskManager.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private UserControl _vistaActual;
        public UserControl VistaActual
        {
            get => _vistaActual;
            set
            {
                _vistaActual = value;
                OnPropertyChanged();
            }
        }

        public ICommand AbrirTareasCommand { get; }
        public ICommand AbrirCategoriasCommand { get; }
        public ICommand AbrirUsuariosCommand { get; }

        private readonly AppDbContext _context;
        private readonly TareaService _tareaService;
        private readonly UsuarioService _usuarioService;
        private readonly CategoriaService _categoriaService;

        public MainViewModel()
        {
            _context = new AppDbContext();
            _tareaService = new TareaService(_context);
            _usuarioService = new UsuarioService(_context);
            _categoriaService = new CategoriaService(_context);

            AbrirTareasCommand = new RelayCommand(_ => AbrirTareas());
            AbrirCategoriasCommand = new RelayCommand(_ => AbrirCategorias());
            AbrirUsuariosCommand = new RelayCommand(_ => AbrirUsuarios());
            // Establecer la vista inicial
            AbrirTareas();
        }

        private void AbrirTareas()
        {
            var tareaViewModel = new TareaViewModel(_tareaService, _usuarioService, _categoriaService);
            VistaActual = new TaskView { DataContext = tareaViewModel };
        }

        private void AbrirCategorias()
        {
            var categoriaViewModel = new CategoriaViewModel(_categoriaService);
            VistaActual = new CategoriaView { DataContext = categoriaViewModel };
        }

        private void AbrirUsuarios()
        {
            var usuarioViewModel = new UsuarioViewModel(_usuarioService);
            VistaActual = new UsuariosView { DataContext = usuarioViewModel };
        }
    }
}
