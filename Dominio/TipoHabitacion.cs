﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
  public  class TipoHabitacion
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public float Precio { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
