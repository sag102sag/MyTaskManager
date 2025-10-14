using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MyTaskManager.Models;
using MyTaskManager.Services;

namespace MyTaskManager.ViewModels
{
    public  class UsuarioFormViewModel : BaseViewModel
    {
        private readonly UsuarioService _usuarioService;
        private readonly Window _window;

        public Usuario Usuario { get; set; } = new();

        public string TituloVentana => Usuario.Id == 0 ? "Agregar Usuario" : "Editar Usuario";
        public string TextoBoton => Usuario.Id == 0 ? "Guardar" : "Actualizar";

        public ICommand GuardarCommand { get; }

        public UsuarioFormViewModel(UsuarioService usuarioService, Window window, Usuario usuario = null)
        {
            _usuarioService = usuarioService;
            _window = window;
            if (usuario != null)
            {
                Usuario = usuario;
            }
            GuardarCommand = new RelayCommand(async _ => await GuardarAsync());
        }

        private async Task GuardarAsync()
        {
            if(Usuario.Id == 0)
            {
                await _usuarioService.AddAsync(Usuario);
            }
            else
            {
                await _usuarioService.UpdateAsync(Usuario.Id, Usuario);
            }

            _window.DialogResult = true;
            _window.Close();
        }
    }
}
