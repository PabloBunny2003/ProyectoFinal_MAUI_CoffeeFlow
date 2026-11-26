
using System;
using System.Collections.Generic;
using ProyectoFinal.Core.Abstractions;
using ProyectoFinal.Core.Interfaces;

namespace ProyectoFinal.Infrastructure.Repositories
{
    public class RepositorioEnMemoria<T> : IRepositorio<T>
        where T : EntidadBase
    {
        private readonly List<T> _entidades = new();

        public void Agregar(T entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            _entidades.Add(entidad);
        }

        public IReadOnlyList<T> ObtenerTodos()
        {
            return _entidades.ToArray();
        }

        public int Contar()
        {
            return _entidades.Count;
        }

        public void Limpiar()
        {
            _entidades.Clear();
        }
    }
}
