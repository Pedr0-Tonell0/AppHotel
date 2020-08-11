using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
   public class Alquiler
    {
        public int Id { get; set; }
        public Habitacion Habitacion { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
        public float Costo { get; set; }
     
    }
}
