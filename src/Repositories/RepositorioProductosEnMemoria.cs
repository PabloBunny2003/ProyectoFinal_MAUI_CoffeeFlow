
using System;
using System.Collections.Generic;
using ProyectoFinal.Core.Abstractions;
using ProyectoFinal.Core.Interfaces;

namespace ProyectoFinal.Infrastructure.Repositories
{
    public class RepositorioProductosEnMemoria
        : IRepositorio<Producto>
    {
        private readonly List<Producto> _productos = new();

        public void Agregar(Producto entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            _productos.Add(entidad);
        }

        public IReadOnlyList<Producto> ObtenerTodos()
        {
            return _productos.ToArray();
        }
    }
}
