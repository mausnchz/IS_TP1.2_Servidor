using IS_TP1._2_Servidor.Datos;
using IS_TP1._2_Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Aplicacion
{
    public class ControladorTrabajarOrdenProduccion
    {
        private Repositorio repositorio;
        private DateTime horaActual;
        private OrdenProduccion ordenProduccion;
        private List<TipoTurno> tiposTurno;
        private Usuario usuario;

        public ControladorTrabajarOrdenProduccion()
        {
            repositorio = Repositorio.ObtenerInstancia();
        }

        public OrdenProduccion IncorporarseOrdenProduccion(string numeroOrdenProduccion, string nombreUsuario)
        {
            horaActual = DateTime.Now;
            //horaActual.AddHours(20.0);
            ordenProduccion = repositorio.ObtenerOrdenProduccion(numeroOrdenProduccion);
            tiposTurno = repositorio.ObtenerTiposTurno();
            usuario = repositorio.ObtenerUsuario(nombreUsuario);

            Boolean existeTipoTurno = VerificarExistenciaTipoTurno(horaActual);
            
            if (existeTipoTurno)
            {
                TipoTurno tipoTurno = ObtenerTipoTurno(horaActual);
                Boolean existeEstadoEnCurso = ordenProduccion.VerificarEstadoEnCurso();
                Boolean existeSupervisorCalidadIncorporado = ordenProduccion.VerificarIncorporacionSupervisorCalidad();

                if (!existeSupervisorCalidadIncorporado && existeEstadoEnCurso)
                {
                    Empleado supervisorCalidad = usuario.Empleado;
                    ordenProduccion.IncorporarSupervisorCalidad(supervisorCalidad);
                    Boolean existeTurno = ordenProduccion.VerificarExistenciaTurno(horaActual, tipoTurno);

                    if (!existeTurno)
                    {
                        ordenProduccion.CrearTurno(horaActual, tipoTurno, supervisorCalidad);
                    }
                    else
                    {
                        Boolean existeBloqueTrabajo = ordenProduccion.VerificarExistenciaBloqueTrabajo(horaActual);
                        
                        if (!existeBloqueTrabajo)
                        {
                            ordenProduccion.CrearBloqueTrabajo(horaActual, supervisorCalidad);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Existe un supervisor de calidad asignado a la orden de producción.");
                }
            }
            else
            {
                Console.WriteLine("No existe ningún turno en curso.");
            }

            return ordenProduccion;
        }

        private Boolean VerificarExistenciaTipoTurno(DateTime horaActual)
        {
            foreach(TipoTurno tt in tiposTurno){
                if(horaActual.Hour >= tt.HoraInicio.Hour && horaActual.Hour <= tt.HoraFinalizacion.Hour && horaActual.Minute < tt.HoraFinalizacion.Minute)
                {
                    return true;
                }
            }
            return false;
        }

        private TipoTurno ObtenerTipoTurno(DateTime horaActual)
        {
            TipoTurno tipoTurno = new TipoTurno();

            foreach (TipoTurno tt in tiposTurno)
            {
                if (horaActual.Hour >= tt.HoraInicio.Hour && horaActual.Hour <= tt.HoraFinalizacion.Hour && horaActual.Minute < tt.HoraFinalizacion.Minute)
                {
                    tipoTurno = tt;
                }
            }
            return tipoTurno;
        }

        public List<OrdenProduccion> AbandonarOrdenProduccion(string numeroOrdenProduccion)
        {
            List<LineaTrabajo> lineasTrabajo = repositorio.ObtenerLineasTrabajo();
            OrdenProduccion ordenProduccion = ObtenerOrdenProduccion(numeroOrdenProduccion, lineasTrabajo);
            Boolean existeEstadoPausada = ordenProduccion.VerificarEstadoPausada();

            if (existeEstadoPausada)
            {
                ordenProduccion.LiberarSupervisorCalidad();
            }

            return repositorio.ObtenerOrdenesProduccion();
        }

        private static OrdenProduccion ObtenerOrdenProduccion(string numeroOrdenProduccion, List<LineaTrabajo> lineasTrabajo)
        {
            OrdenProduccion ordenProduccion = new OrdenProduccion();

            foreach (LineaTrabajo lt in lineasTrabajo)
            {
                foreach (OrdenProduccion op in lt.OrdenesProduccion)
                {
                    if (op.Numero == numeroOrdenProduccion)
                    {
                        ordenProduccion = op;
                    }
                }
            }

            return ordenProduccion;
        }

        public List<OrdenProduccion> ObtenerOrdenesProduccion()
        {
            return repositorio.ObtenerOrdenesProduccion();
        }
    }
}
