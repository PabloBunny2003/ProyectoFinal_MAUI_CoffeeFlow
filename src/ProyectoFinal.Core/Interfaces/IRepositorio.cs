
using System.Collections.Generic;
using ProyectoFinal.Core.Abstractions;

namespace ProyectoFinal.Core.Interfaces
{
    public interface IRepositorio<T>
        where T : EntidadBase
    {
        void Agregar(T entidad);

        IReadOnlyList<T> ObtenerTodos();
    }
}
