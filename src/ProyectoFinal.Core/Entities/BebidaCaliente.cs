
using System;
using ProyectoFinal.Core.Abstractions;

namespace ProyectoFinal.Core.Entities
{
    public class BebidaCaliente : Producto
    {
        private double _temperatura;

        public double Temperatura
        {
            get => _temperatura;
            set
            {
                if (!double.IsFinite(value) ||
                    value < 30 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Temperatura),
                        "La temperatura debe estar entre 30 y 100 °C."
                    );
                }

                _temperatura = value;
            }
        }

        public BebidaCaliente(
            string nombre,
            decimal precio,
            int stock,
            double temperatura)
            : base(nombre, precio, stock)
        {
            Temperatura = temperatura;
        }

        public override string ObtenerDescripcion()
        {
            return $"{Nombre} | Bebida caliente | " +
                   $"{Temperatura} °C | ${Precio:F2}";
        }
    }
}
