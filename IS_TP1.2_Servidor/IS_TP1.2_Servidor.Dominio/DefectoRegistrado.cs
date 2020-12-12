﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class DefectoRegistrado
    {
        public Defecto Defecto { get; set; }
        public Orientacion Orientacion { get; set; }

        public DefectoRegistrado(Defecto defecto, Orientacion orientacion)
        {
            this.Defecto = defecto;
            this.Orientacion = orientacion;
        }

    }
}