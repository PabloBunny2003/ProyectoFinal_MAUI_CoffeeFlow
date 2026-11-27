
using System;
using System.Linq;
using System.Collections.ObjectModel;
using ProyectoFinal.Core.Abstractions;
using ProyectoFinal.Core.Entities;
using ProyectoFinal.App.Services;

namespace ProyectoFinal.App.ViewModels
{
    public class ProductosViewModel : BaseViewModel
    {
        private string _busqueda = string.Empty;
        private string _categoriaSeleccionada = "Todos";

        public ObservableCollection<Producto> Productos
        {
            get;
        } = new();

        public string[] Categorias { get; } =
        {
            "Todos",
            "Bebidas calientes",
            "Bebidas frías",
            "Alimentos"
        };

        public string Busqueda
        {
            get => _busqueda;
            set
            {
                if (SetProperty(ref _busqueda, value))
                {
                    FiltrarProductos();
                }
            }
        }

        public string CategoriaSeleccionada
        {
            get => _categoriaSeleccionada;
            set
            {
                if (SetProperty(
                    ref _categoriaSeleccionada, value))
                {
                    FiltrarProductos();
                }
            }
        }

        public int TotalResultados => Productos.Count;

        public ProductosViewModel()
        {
            Title = "Productos";

            FiltrarProductos();
        }

        public void FiltrarProductos()
        {
            var consulta = CatalogoService.Productos
                .AsEnumerable();

            // Búsqueda por nombre
            if (!string.IsNullOrWhiteSpace(Busqueda))
            {
                consulta = consulta.Where(producto =>
                    producto.Nombre.Contains(
                        Busqueda.Trim(),
                        StringComparison.OrdinalIgnoreCase));
            }

            // Filtro por categoría
            consulta = CategoriaSeleccionada switch
            {
                "Bebidas calientes" =>
                    consulta.Where(p => p is BebidaCaliente),

                "Bebidas frías" =>
                    consulta.Where(p => p is BebidaFria),

                "Alimentos" =>
                    consulta.Where(p => p is Alimento),

                _ => consulta
            };

            var resultados = consulta.ToList();

            Productos.Clear();

            foreach (Producto producto in resultados)
            {
                Productos.Add(producto);
            }

            OnPropertyChanged(nameof(TotalResultados));
        }
    }
}
