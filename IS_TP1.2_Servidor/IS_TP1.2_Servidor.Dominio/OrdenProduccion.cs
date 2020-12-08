using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class OrdenProduccion
    {
        public string Numero { get; set; }
        public Modelo Modelo { get; set; }
        public Color Color { get; set; }
        public EstadoOrdenProduccion Estado { get; set; }
        public Empleado SupervisorLinea { get; set; }
        public Empleado SupervisorCalidadIncorporado{ get; set; }
        public List<Turno> Turnos { get; set; }

    }
}
