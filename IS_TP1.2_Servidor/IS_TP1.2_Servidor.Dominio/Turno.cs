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
        public int CantidadParesHermanadosPrimeraCalidad { get; set; }
        public int CantidadParesHermanadosSegundaCalidad { get; set; }
        public List<BloqueTrabajo> BloquesTrabajo { get; set; }

    }
}
