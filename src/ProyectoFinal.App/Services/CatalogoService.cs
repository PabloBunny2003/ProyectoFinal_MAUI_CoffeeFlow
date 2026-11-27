
using System.Collections.ObjectModel;
using ProyectoFinal.Core.Abstractions;
using ProyectoFinal.Core.Entities;

namespace ProyectoFinal.App.Services
{
    public static class CatalogoService
    {
        public static ObservableCollection<Producto> Productos
        { get; } = new()
        {
            new BebidaCaliente(
                "Cappuccino", 65m, 20, 65)
            {
                Id = 1
            },

            new BebidaFria(
                "Cold Brew", 75m, 15, true)
            {
                Id = 2
            },

            new Alimento(
                "Croissant de mantequilla", 45m, 12, true)
            {
                Id = 3
            }
        };
    }
}
