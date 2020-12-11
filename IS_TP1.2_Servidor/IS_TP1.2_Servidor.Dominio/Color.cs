using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class Color
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public Color(string codigo, string descripcion)
        {
            this.Codigo = codigo;
            this.Descripcion = descripcion;
        }

    }
}
