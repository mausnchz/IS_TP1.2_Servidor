using IS_TP1._2_Servidor.Dominio;
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
            return baseDatos.ObtenerUsuarios().Where(z => z.Nombre == nombreUsuario).FirstOrDefault();
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
    }
}
