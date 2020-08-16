using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  public  class TipoHabitacion
    {
        public int Id { get; set; }

        public int Alquiladas{ get; set; }

        public int Disponibles { get; set; }

        public string Nombre { get; set; }

        public Decimal Precio { get; set; }

        public string Descripcion { get; set; }


        public override string ToString()
        {
            return Nombre;
        }
    }
}
