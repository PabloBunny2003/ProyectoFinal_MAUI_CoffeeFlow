
using ProyectoFinal.Core.Abstractions;

namespace ProyectoFinal.Core.Entities
{
    public class BebidaFria : Producto
    {
        private bool _tieneHielo;

        public bool TieneHielo
        {
            get => _tieneHielo;
            set => _tieneHielo = value;
        }

        public BebidaFria(
            string nombre,
            decimal precio,
            int stock,
            bool tieneHielo)
            : base(nombre, precio, stock)
        {
            TieneHielo = tieneHielo;
        }

        public override string ObtenerDescripcion()
        {
            string hielo = TieneHielo
                ? "Con hielo"
                : "Sin hielo";

            return $"{Nombre} | Bebida fría | " +
                   $"{hielo} | ${Precio:F2}";
        }
    }
}
