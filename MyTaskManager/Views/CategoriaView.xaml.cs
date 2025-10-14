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
using MyTaskManager.Services;
using MyTaskManager.ViewModels;

namespace MyTaskManager.Views
{
    /// <summary>
    /// Lógica de interacción para CategoriaView.xaml
    /// </summary>
    public partial class CategoriaView : UserControl
    {
        private CategoriaViewModel _viewModel;
        public CategoriaView()
        {
            InitializeComponent();

            var context = new Data.AppDbContext();
            var categoriaService = new CategoriaService(context);

            _viewModel = new CategoriaViewModel(categoriaService);
            DataContext = _viewModel;
        }
    }
}
