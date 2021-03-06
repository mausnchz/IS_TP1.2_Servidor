﻿using IS_TP1._2_Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Datos
{
    public sealed class Repositorio
    {
        private static Repositorio instancia;
        private BaseDatos baseDatos;

        private Repositorio()
        {
            baseDatos = BaseDatos.ObtenerInstancia();
        }

        public static Repositorio ObtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new Repositorio();
            }
            return instancia;
        }

        public List<Modelo> InsertarNuevoModelo(Modelo modelo)
		{
             return baseDatos.InsertarNuevoModelo(modelo);

        }

        public List<Modelo> ObtenerModelos()
		{
            return baseDatos.ObtenerModelos();
		}

        public List<Color> InsertarNuevoColor(Color color)
        {
            return baseDatos.InsertarNuevoColor(color);

        }

        public List<Color> ObtenerColores()
        {
            return baseDatos.ObtenerColores();
        }

        public List<LineaTrabajo> ObtenerLineas()
        {
            return baseDatos.ObtenerLineasTrabajo();
        }

        public OrdenProduccion ObtenerOrdenProduccion(string numeroOrdenProduccion)
        {
            return baseDatos.ObtenerOrdenesProduccion().Where(z => z.Numero == numeroOrdenProduccion).FirstOrDefault();
        }

        public List<TipoTurno> ObtenerTiposTurno()
        {
            return baseDatos.ObtenerTiposTurno();
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            var usuarios = baseDatos.ObtenerUsuarios();
            foreach(Usuario u in usuarios)
			{
                if (u.Nombre == nombreUsuario) {
                    return u;
                };
			}
            return null;
        }



        public List<OrdenProduccion> ObtenerOrdenesProduccion()
        {

            return baseDatos.ObtenerOrdenesProduccion();
        }

        public List<LineaTrabajo> ObtenerLineasTrabajo()
        {
            return baseDatos.ObtenerLineasTrabajo();
        }

        public Defecto ObtenerDefecto(string tipoDefecto, string nombreDefecto)
        {
            return baseDatos.ObtenerDefectos().FirstOrDefault(z => z.Tipo.Descripcion == tipoDefecto
                && z.Descripcion == nombreDefecto);
        }

        public List<TipoTurno> ObtenerTiposTurnos()
		{
            return baseDatos.ObtenerTiposTurno();
        }

        public List<OrdenProduccion> IniciarOrdenProduccion(string numeroOP, int indexModelo, int indexColor, int indexEmpleado,
            List<Turno> turnos)
		{
            return baseDatos.IniciarOrdenProduccion(numeroOP, indexModelo,  indexColor,  indexEmpleado,
           turnos);
		}
    }
}
