using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class Empleado
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string DNI { get; set; }
        public string Correo { get; set; }
        public Cargo Cargo { get; set; }

        public Empleado(string apellido, string nombre, string dni, string correo, Cargo cargo)
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.DNI = dni;
            this.Correo = correo;
            this.Cargo = cargo;
        }
    }
}
