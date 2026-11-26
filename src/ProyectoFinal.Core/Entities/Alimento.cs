
using ProyectoFinal.Core.Abstractions;

namespace ProyectoFinal.Core.Entities
{
    public class Alimento : Producto
    {
        private bool _esVegetariano;

        public bool EsVegetariano
        {
            get => _esVegetariano;
            set => _esVegetariano = value;
        }

        public Alimento(
            string nombre,
            decimal precio,
            int stock,
            bool esVegetariano)
            : base(nombre, precio, stock)
        {
            EsVegetariano = esVegetariano;
        }

        public override string ObtenerDescripcion()
        {
            string tipo = EsVegetariano
                ? "Vegetariano"
                : "No vegetariano";

            return $"{Nombre} | Alimento | " +
                   $"{tipo} | ${Precio:F2}";
        }
    }
}
