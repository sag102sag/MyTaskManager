using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyTaskManager.Data;
using MyTaskManager.Services;
using MyTaskManager.ViewModels;

namespace MyTaskManager.Views
{
    /// <summary>
    /// Lógica de interacción para TaskView.xaml
    /// </summary>
    public partial class TaskView : UserControl
    {
        private TareaViewModel _viewModel;
        public TaskView()
        {
            InitializeComponent();

            var context = new AppDbContext();
            var tareaService = new TareaService(context);
            var usuarioService = new UsuarioService(context);
            var categoriaService = new CategoriaService(context);

            _viewModel = new TareaViewModel(tareaService, usuarioService, categoriaService);
            DataContext = _viewModel;
        }
    }
}
