
using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoFinal.Core.Abstractions;

namespace ProyectoFinal.Core.Generics
{
    public static class ConsultasProductos
    {
        public static List<T> ObtenerDisponibles<T>(
            IEnumerable<T> productos)
            where T : Producto
        {
            ArgumentNullException.ThrowIfNull(productos);

            return productos
                .Where(producto => producto.TieneDisponibilidad())
                .ToList();
        }

        public static decimal CalcularValorInventario<T>(
            IEnumerable<T> productos)
            where T : Producto
        {
            ArgumentNullException.ThrowIfNull(productos);

            return productos.Sum(
                producto => producto.Precio * producto.Stock);
        }
    }
}
