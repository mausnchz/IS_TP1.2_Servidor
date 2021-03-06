﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class TipoTurno
    {
        public string Descripcion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinalizacion { get; set; }

        public TipoTurno() { }
        public TipoTurno(string descripcion, DateTime horaInicio, DateTime horaFinalizacion)
        {
            this.Descripcion = descripcion;
            this.HoraInicio = horaInicio;
            this.HoraFinalizacion = horaFinalizacion;
        }

    }
}
