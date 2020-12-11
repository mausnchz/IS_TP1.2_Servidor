using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class Turno
    {
        public DateTime Fecha { get; set; }
        public TipoTurno Tipo { get; set; }
        public int CantidadParesHermanadosPrimeraCalidad { get; set; }
        public int CantidadParesHermanadosSegundaCalidad { get; set; }
        public List<BloqueTrabajo> BloquesTrabajo { get; set; }

        public Turno(DateTime fecha, TipoTurno tipoTurno, int cantidadParesHermanadosPrimeraCalidad,
            int cantidadParesHermanadosSegundaCalidad, List<BloqueTrabajo> bloquesTrabajo)
        {
            this.Fecha = fecha;
            this.Tipo = tipoTurno;
            this.CantidadParesHermanadosPrimeraCalidad = cantidadParesHermanadosPrimeraCalidad;
            this.CantidadParesHermanadosSegundaCalidad = cantidadParesHermanadosSegundaCalidad;
            this.BloquesTrabajo = bloquesTrabajo;
        }

        public Turno(DateTime horaActual, TipoTurno tipoTurno, Empleado supervisorCalidad)
        {
            Tipo = tipoTurno;
            Fecha = horaActual.Date;
            BloquesTrabajo = new List<BloqueTrabajo>();
            
            BloqueTrabajo bloqueTrabajo = new BloqueTrabajo(horaActual, supervisorCalidad);
            BloquesTrabajo.Add(bloqueTrabajo);
        }

        public void CrearBloqueTrabajo(DateTime horaActual, Empleado supervisorCalidad)
        {
            BloqueTrabajo bloqueTrabajo = new BloqueTrabajo(horaActual, supervisorCalidad);
            BloquesTrabajo.Add(bloqueTrabajo);
        }
    }
}
