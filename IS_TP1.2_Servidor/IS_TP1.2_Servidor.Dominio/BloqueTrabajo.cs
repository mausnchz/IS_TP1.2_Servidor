using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class BloqueTrabajo
    {
        public int Hora { get; set; }
        public int CantidadParesPrimeraCalidad { get; set; }
        public Empleado SupervisorCalidad { get; set; }
        public List<DefectoRegistrado> DefectosRegistrados { get; set; }

        public BloqueTrabajo(DateTime horaActual, Empleado supervisorCalidad)
        {
            Hora = horaActual.Hour;
            SupervisorCalidad = supervisorCalidad;
            DefectosRegistrados = new List<DefectoRegistrado>();
        }
    }
}
