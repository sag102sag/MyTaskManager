using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyTaskManager;
using MyTaskManager.Models;
using MyTaskManager.Services;
using MyTaskManager.ViewModels;
using MyTaskManager.Views;

public class TareaViewModel : BaseViewModel
{
    private readonly TareaService _tareaService;
    private readonly UsuarioService _usuarioService;
    private readonly CategoriaService _categoriaService;

    public ObservableCollection<Tarea> Tareas { get; set; } = new();

    public ICommand DeleteTareaCommand { get; }
    public ICommand AddTareaCommand { get; }
    public ICommand EditarTareaCommand { get; }

    public TareaViewModel(TareaService tareaService, UsuarioService usuarioService, CategoriaService categoriaService)
    {
        _tareaService = tareaService;
        _usuarioService = usuarioService;
        _categoriaService = categoriaService;

        DeleteTareaCommand = new RelayCommand(async tarea => await DeleteTarea((Tarea)tarea));
        EditarTareaCommand = new RelayCommand(async tarea => await AbrirFormulario((Tarea)tarea));
        AddTareaCommand = new RelayCommand(async _ => await AbrirFormulario(null));

        _ = CargarTareas();
    }

    public async Task CargarTareas()
    {
        var listaTareas = await _tareaService.GetAllAsync();
        Tareas.Clear();
        foreach (var tarea in listaTareas)
            Tareas.Add(tarea);
    }

    public async Task DeleteTarea(Tarea tarea)
    {
        if (tarea == null) return;
        await _tareaService.DeleteAsync(tarea.Id);
        Tareas.Remove(tarea);
    }

    public async Task AbrirFormulario(Tarea tarea)
    {
        var window = new TareaFormWindow(_tareaService, _usuarioService, _categoriaService, tarea);
        bool? result = window.ShowDialog();

        if (result == true)
            await CargarTareas();
    }
}
