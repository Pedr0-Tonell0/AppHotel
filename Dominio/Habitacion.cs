using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  public  class Habitacion
    {
        public int Numero { get; set; }
        public int Piso { get; set; }

        public TipoHabitacion Tipo { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }


    }
}
