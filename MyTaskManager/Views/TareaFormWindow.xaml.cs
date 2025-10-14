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
using System.Windows.Shapes;
using MyTaskManager.Models;
using MyTaskManager.Services;
using MyTaskManager.ViewModels;

namespace MyTaskManager.Views
{
    /// <summary>
    /// Lógica de interacción para TareaFormWindow.xaml
    /// </summary>
    public partial class TareaFormWindow : Window
    {
        public TareaFormWindow(TareaService tareaService, UsuarioService usuarioService, CategoriaService categoriaService, Tarea tarea = null)
        {
            InitializeComponent();
            DataContext = new TareaFormViewModel(tareaService, usuarioService, categoriaService, this, tarea);   
        }
    }
}
