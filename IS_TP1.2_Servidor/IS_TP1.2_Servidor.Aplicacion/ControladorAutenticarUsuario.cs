using IS_TP1._2_Servidor.Datos;
using IS_TP1._2_Servidor.Dominio;
using System;

namespace IS_TP1._2_Servidor.Aplicacion
{
	public class ControladorAutenticarUsuario
    {
        private Usuario usuario;
        private Repositorio repositorio;
        private Empleado empleado;
        public ControladorAutenticarUsuario()
        {
            repositorio = Repositorio.ObtenerInstancia();

        }

        public Boolean autenticarUsuario(string nombreUsuario, string contraseña)
        {
            usuario = BuscarYValidarUsuarioYContraseña(nombreUsuario, contraseña);

            if (usuario != null)
            {
                empleado = usuario.Empleado;

                return true;

            }
            else
            {
                Console.WriteLine("Usuario y / o contraseña incorrectos");
                return false;
            }

        }

        public Usuario BuscarYValidarUsuarioYContraseña(string nombreUsuario, string contraseña)
        {
            Usuario usuario;
            usuario = repositorio.ObtenerUsuario(nombreUsuario);

            if (usuario != null)
            {
                if (usuario.validarContraseña(contraseña))
                {
                    return usuario;
                }

            }

            return null;
        }
    }
}
