using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class BloqueTrabajo
    {
        public DateTime Hora { get; set; }
        public int CantidadParesPrimeraCalidad { get; set; }
        public Empleado SupervisorCalidad { get; set; }
    }
}
