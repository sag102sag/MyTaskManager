using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MyTaskManager.Models;
using MyTaskManager.Services;

namespace MyTaskManager.ViewModels
{
    public class CategoriaViewModel : BaseViewModel
    {
        private readonly CategoriaService _categoriaService;
        public ObservableCollection<Categoria> Categorias { get; set; } = new();
        public ICommand DeleteCategoriaCommand { get; set; }

        public CategoriaViewModel(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
            DeleteCategoriaCommand = new RelayCommand(async categoria => await EliminarCategoriaAsync((Categoria)categoria));

            _ = CargarCategorias();
        }

        public async Task CargarCategorias()
        {
            var listaCategorias = await _categoriaService.GetAllAsync();
            Categorias.Clear();
            foreach (var categoria in listaCategorias)
            {
                Categorias.Add(categoria);
            }
        }

        public async Task EliminarCategoriaAsync(Categoria categoria)
        {
            try
            {
                await _categoriaService.DeleteCategoriaAsync(categoria.Id);
                Categorias.Remove(categoria);
            }
            catch (InvalidOperationException ex)
            {

                MessageBox.Show(ex.Message, "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
