
using System;

namespace ProyectoFinal.Core.Abstractions
{
    public abstract class EntidadBase
    {
        private int _id;
        private DateTime _fechaCreacion = DateTime.UtcNow;

        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Id),
                        "El identificador no puede ser negativo."
                    );
                }

                _id = value;
            }
        }

        public DateTime FechaCreacion
        {
            get => _fechaCreacion;
            set
            {
                if (value > DateTime.UtcNow)
                {
                    throw new ArgumentException(
                        "La fecha de creación no puede ser futura."
                    );
                }

                _fechaCreacion = value;
            }
        }
    }
}
