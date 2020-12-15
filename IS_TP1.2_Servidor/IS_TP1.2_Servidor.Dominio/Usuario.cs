using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public Empleado Empleado { get; set; }

        public Usuario(string nombre, string contraseña, Empleado empleado)
        {
            this.Nombre = nombre;
            this.Contraseña = contraseña;
            this.Empleado = empleado;
        }
        public Boolean validarContraseña(String contraseña)
        {
            if (this.Contraseña.Equals(contraseña))
            {
                return true;
            }
            return false;
        }
    }
}
