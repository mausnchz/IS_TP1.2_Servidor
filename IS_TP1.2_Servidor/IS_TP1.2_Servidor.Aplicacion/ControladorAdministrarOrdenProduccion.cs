using IS_TP1._2_Servidor.Datos;
using IS_TP1._2_Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Aplicacion
{
    public class ControladorAdministrarOrdenProduccion
    {
        private Repositorio repositorio;

        public ControladorAdministrarOrdenProduccion()
        {
            repositorio = Repositorio.ObtenerInstancia();
        }

        public List<OrdenProduccion> RegistrarPausaOrdenProduccion(string numeroOrdenProduccion)
        {
            OrdenProduccion ordenProduccion = repositorio.ObtenerOrdenProduccion(numeroOrdenProduccion);
            Boolean existeEstadoNoFinalizado = ordenProduccion.VerificarEstadoNoFinalizado();

            if (existeEstadoNoFinalizado)
            {
                ordenProduccion.PausarOrdenProduccion();
            }
            else
            {
                Console.WriteLine("La orden de producción se encuentra finalizada.");
            }

            return repositorio.ObtenerOrdenesProduccion();
        }
    }
}
