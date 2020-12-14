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

        public List<OrdenProduccion> RegistrarReanudacionOrdenProduccion(string numeroOrdenProduccion)
        {
            OrdenProduccion ordenProduccion = repositorio.ObtenerOrdenProduccion(numeroOrdenProduccion);
            DateTime horaActual = DateTime.Now;
            List<TipoTurno> tiposTurno = repositorio.ObtenerTiposTurno();
            Boolean horaActualCorrespondeTipoTurno = false;
            Boolean existeEstadoNoFinalizado = true;

            foreach (TipoTurno tt in tiposTurno)
            {
                if(horaActual.Hour >= tt.HoraInicio.Hour && horaActual.Hour < tt.HoraFinalizacion.Hour)
                {
                    horaActualCorrespondeTipoTurno = true;
                }
            }

            existeEstadoNoFinalizado = ordenProduccion.VerificarEstadoNoFinalizado();

            if (horaActualCorrespondeTipoTurno && existeEstadoNoFinalizado)
            {
                ordenProduccion.ReanudarOrdenProduccion();
            }

            return repositorio.ObtenerOrdenesProduccion();
        }

        public List<OrdenProduccion> RegistrarFinalizacionOrdenProduccion(string numeroOrdenProduccion)
        {
            OrdenProduccion ordenProduccion = repositorio.ObtenerOrdenProduccion(numeroOrdenProduccion);
            DateTime horaActual = DateTime.Now;
            List<TipoTurno> tiposTurno = repositorio.ObtenerTiposTurno();
            Boolean horaActualCorrespondeTipoTurnoHolgado = false;

            foreach (TipoTurno tt in tiposTurno)
            {
                if (horaActual.Hour >= tt.HoraInicio.Hour && horaActual.Hour < tt.HoraFinalizacion.Hour)
                {
                    horaActualCorrespondeTipoTurnoHolgado = true;
                }
                else if (horaActual.Hour == tt.HoraFinalizacion.Hour && horaActual.Minute < 30)
                {
                    horaActualCorrespondeTipoTurnoHolgado = true;
                }
            }

            if (horaActualCorrespondeTipoTurnoHolgado)
            {
                ordenProduccion.FinalizarOrdenProduccion();
            }

            return repositorio.ObtenerOrdenesProduccion();
        }
    }
}
