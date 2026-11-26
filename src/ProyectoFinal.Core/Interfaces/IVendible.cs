
namespace ProyectoFinal.Core.Interfaces
{
    public interface IVendible
    {
        decimal Precio { get; }

        bool TieneDisponibilidad();

        decimal CalcularImporte(int cantidad);
    }
}
