using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyTaskManager.Models;
using MyTaskManager.Services;
using MyTaskManager.Views;

namespace MyTaskManager.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        private readonly UsuarioService _usuarioService;

        public ObservableCollection<Usuario> Usuarios { get; set; } = new();

        private Usuario _usuarioSeleccionado;
        public Usuario UsuarioSeleccionado
        {
            get => _usuarioSeleccionado;
            set
            {
                _usuarioSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public UsuarioViewModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            AddUsuarioCommand = new RelayCommand(async _ => await AbrirFormulario(null));
            EditarUsuarioCommand = new RelayCommand(async usuario => await AbrirFormulario((Usuario) usuario));
            DeleteUsuarioCommand = new RelayCommand(async usuario => await DeleteUsuario((Usuario)usuario));
            DeleteUltimoUsuarioCommand = new RelayCommand(async _ => await DeleteUltimoUsuario());
            _ =CargarUsuarios();
        }

        public ICommand AddUsuarioCommand { get; }
        public ICommand EditarUsuarioCommand { get; }
        public ICommand DeleteUsuarioCommand { get; }
        public ICommand DeleteUltimoUsuarioCommand { get; }


        public async Task CargarUsuarios()
        {
            var listaUsuarios = await _usuarioService.GetAllAsync();
            Usuarios.Clear();
            foreach (var usuario in listaUsuarios)
            {
                Usuarios.Add(usuario);
            }
        }

        public async Task AbrirFormulario(Usuario usuario)
        {
            var window = new UsuarioFormWindow(_usuarioService, usuario);
            bool? result = window.ShowDialog();

            if(result == true)
            {
                await CargarUsuarios();
            }
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                await _usuarioService.DeleteAsync(usuario.Id);
                Usuarios.Remove(usuario);
            }
        }
        // asd

        public async Task DeleteUltimoUsuario()
        {
            var usuario = Usuarios.LastOrDefault();
            if (usuario != null)
            {
                await _usuarioService.DeleteAsync(usuario.Id);
                Usuarios.Remove(usuario);
            }
        }
    }
}
