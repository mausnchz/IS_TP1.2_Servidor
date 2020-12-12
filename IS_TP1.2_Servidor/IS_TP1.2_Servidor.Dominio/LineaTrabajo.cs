using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class LineaTrabajo
    {
        public string Numero { get; set; }
        public List<OrdenProduccion> OrdenesProduccion { get; set; }

        public LineaTrabajo(string numero, List<OrdenProduccion> ordenesProduccion)
        {
            this.Numero = numero;
            this.OrdenesProduccion = ordenesProduccion;
        }
    }
}
