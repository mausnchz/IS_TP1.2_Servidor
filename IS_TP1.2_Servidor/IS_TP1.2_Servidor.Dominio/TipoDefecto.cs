﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class TipoDefecto
    {
        public string Descripcion { get; set; }

        public TipoDefecto(string descripcion)
        {
            this.Descripcion = descripcion;
        }
    }
}
