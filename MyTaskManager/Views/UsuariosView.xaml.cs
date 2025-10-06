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
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UsuariosView : UserControl
    {
        private UsuarioViewModel _viewModel;

        public UsuariosView()
        {
            InitializeComponent();

            var context = new AppDbContext();
            var usuarioService = new UsuarioService(context);

            _viewModel = new UsuarioViewModel(usuarioService);
            DataContext = _viewModel;
        }
    }
}
