using MyTaskManager.Models;
using MyTaskManager.Services;
using MyTaskManager.ViewModels;
using MyTaskManager;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

public class TareaFormViewModel : BaseViewModel
{
    private readonly TareaService _tareaService;
    private readonly UsuarioService _usuarioService;
    private readonly CategoriaService _categoriaService;
    private readonly Window _window;
    private readonly Tarea _tareaOriginal;

    public Tarea TareaTemporal { get; set; }
    public ObservableCollection<Usuario> Usuarios { get; } = new();
    public ObservableCollection<Categoria> Categorias { get; } = new();
    public string TituloFormularioTarea => TareaTemporal.Id == 0 ? "Agregar Tarea" : "Editar Tarea";
    public string ContenidoBotonFormularioTarea => TareaTemporal.Id == 0 ? "Guardar" : "Actualizar";
    public ICommand GuardarCommand { get; }

    public TareaFormViewModel(TareaService tareaService, UsuarioService usuarioService, CategoriaService categoriaService, Window window, Tarea tarea = null)
    {
        _tareaService = tareaService;
        _usuarioService = usuarioService;
        _categoriaService = categoriaService;
        _window = window;
        _tareaOriginal = tarea;

        // Instancia temporal
        TareaTemporal = tarea != null ? tarea.Clonar() : new Tarea { FechaCreacion = DateTime.Now };

        GuardarCommand = new RelayCommand(async _ => await GuardarAsync());
        _ = CargarListasAsync();
    }

    private async Task GuardarAsync()
    {
        if (TareaTemporal.Id == 0)
        {
            await _tareaService.AddAsync(TareaTemporal);
        }
        else
        {
            // Actualizamos el objeto original con los valores del temporal
            _tareaOriginal.Titulo = TareaTemporal.Titulo;
            _tareaOriginal.Descripcion = TareaTemporal.Descripcion;
            _tareaOriginal.FechaCreacion = TareaTemporal.FechaCreacion;
            _tareaOriginal.UsuarioId = TareaTemporal.UsuarioId;
            _tareaOriginal.Usuario = TareaTemporal.Usuario;
            _tareaOriginal.CategoriaId = TareaTemporal.CategoriaId;
            _tareaOriginal.Categoria = TareaTemporal.Categoria;

            await _tareaService.UpdateAsync(TareaTemporal.Id, _tareaOriginal);
        }

        _window.DialogResult = true;
        _window.Close();
    }

    private async Task CargarListasAsync()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        var categorias = await _categoriaService.GetAllAsync();

        Usuarios.Clear();
        foreach (var u in usuarios) Usuarios.Add(u);

        Categorias.Clear();
        foreach (var c in categorias) Categorias.Add(c);
    }
}