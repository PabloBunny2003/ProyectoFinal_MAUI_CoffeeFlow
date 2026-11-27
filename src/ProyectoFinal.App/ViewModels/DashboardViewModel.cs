
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ProyectoFinal.Core.Abstractions;
using ProyectoFinal.Core.Generics;
using ProyectoFinal.App.Services;

namespace ProyectoFinal.App.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private int _totalProductos;
        private int _totalExistencias;
        private int _productosDisponibles;
        private decimal _valorInventario;

        public ObservableCollection<Producto> Productos
        {
            get;
        } = CatalogoService.Productos;

        public int TotalProductos
        {
            get => _totalProductos;
            set => SetProperty(ref _totalProductos, value);
        }

        public int TotalExistencias
        {
            get => _totalExistencias;
            set => SetProperty(ref _totalExistencias, value);
        }

        public int ProductosDisponibles
        {
            get => _productosDisponibles;
            set => SetProperty(ref _productosDisponibles, value);
        }

        public decimal ValorInventario
        {
            get => _valorInventario;
            set => SetProperty(ref _valorInventario, value);
        }

        public ICommand ActualizarCommand { get; }

        public DashboardViewModel()
        {
            Title = "Dashboard";

            ActualizarCommand = new Command(
                ActualizarIndicadores);

            Productos.CollectionChanged += (_, _) =>
                ActualizarIndicadores();

            ActualizarIndicadores();
        }

        public void ActualizarIndicadores()
        {
            TotalProductos = Productos.Count;

            TotalExistencias = Productos.Sum(
                producto => producto.Stock);

            ProductosDisponibles =
                ConsultasProductos
                    .ObtenerDisponibles<Producto>(Productos)
                    .Count;

            ValorInventario =
                ConsultasProductos
                    .CalcularValorInventario<Producto>(Productos);
        }
    }
}
