
using System;

namespace ProyectoFinal.Core.Abstractions
{
    public abstract class Producto : EntidadBase
    {
        private string _nombre = string.Empty;
        private decimal _precio;
        private int _stock;

        public string Nombre
        {
            get => _nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "El nombre del producto es obligatorio."
                    );
                }

                _nombre = value.Trim();
            }
        }

        public decimal Precio
        {
            get => _precio;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Precio),
                        "El precio debe ser mayor que cero."
                    );
                }

                _precio = value;
            }
        }

        public int Stock
        {
            get => _stock;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Stock),
                        "El stock no puede ser negativo."
                    );
                }

                _stock = value;
            }
        }

        protected Producto(
            string nombre,
            decimal precio,
            int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }

        public abstract string ObtenerDescripcion();

        public virtual bool TieneDisponibilidad()
        {
            return Stock > 0;
        }
    }
}
