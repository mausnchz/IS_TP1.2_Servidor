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
        private Repositorio<OrdenProduccion> repositorioOrdenProduccion;
        private Repositorio<TipoTurno> repositorioTipoTurno;
        private Repositorio<Usuario> repositorioUsuario;
        private DateTime horaActual;
        private OrdenProduccion ordenProduccion;
        private List<TipoTurno> tiposTurno;
        private Usuario usuario;

        public ControladorTrabajarOrdenProduccion()
        {
            repositorioOrdenProduccion = new Repositorio<OrdenProduccion>();
            repositorioTipoTurno = new Repositorio<TipoTurno>();
            repositorioUsuario = new Repositorio<Usuario>();
        }
        public OrdenProduccion ObtenerOrdenProduccion(string numeroOrdenProduccion, string nombreUsuario)
        {
            horaActual = new DateTime();
            ordenProduccion = repositorioOrdenProduccion.ObtenerPorFiltro(z => z.Numero == numeroOrdenProduccion).FirstOrDefault();
            tiposTurno = repositorioTipoTurno.ObtenerTodos().ToList();
            usuario = repositorioUsuario.ObtenerPorFiltro(z => z.Nombre == nombreUsuario).FirstOrDefault();

            Boolean existeTipoTurno = VerificarExistenciaTipoTurno(horaActual);
            
            if (existeTipoTurno)
            {
                TipoTurno tipoTurno = ObtenerTipoTurno(horaActual);
                Boolean existeEstadoEnCurso = ordenProduccion.VerificarEstadoEnCurso();
                Boolean existeSupervisorCalidadIncorporado = ordenProduccion.VerificarIncorporacionSupervisorCalidad();

                if (!existeSupervisorCalidadIncorporado)
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

            repositorioOrdenProduccion.GuardarCambios();
            return ordenProduccion;
        }

        private Boolean VerificarExistenciaTipoTurno(DateTime horaActual)
        {
            foreach(TipoTurno tt in tiposTurno){
                if(horaActual.Hour >= tt.HoraInicio.Hour && horaActual.Hour < tt.HoraFinalizacion.Hour)
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
                if (horaActual.Hour >= tt.HoraInicio.Hour && horaActual.Hour < tt.HoraFinalizacion.Hour)
                {
                    tipoTurno = tt;
                }
            }
            return tipoTurno;
        }
    }
}
