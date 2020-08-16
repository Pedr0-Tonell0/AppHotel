using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Alquilar
    {
        public int Id { get; set; }
        public Habitacion Habitacion { get; set; }
        public TipoHabitacion Tipo { get; set; }

        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }

        public Empleado Empleado2 { get; set; }

        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
        public Decimal Precio { get; set; }
     
    }
}
