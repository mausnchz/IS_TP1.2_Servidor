﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class Cargo
    {
        public string Descripcion { get; set; }

        public Cargo(string descripcion)
        {
            this.Descripcion = descripcion;
        }
    }
}
