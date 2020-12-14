using IS_TP1._2_Servidor.Datos;
using IS_TP1._2_Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Aplicacion
{
    public class ControladorRegistrarHallazgosOrdenProduccion
    {
        private Repositorio repositorio;

        public ControladorRegistrarHallazgosOrdenProduccion()
        {
            repositorio = Repositorio.ObtenerInstancia();
        }

        public OrdenProduccion GestionarDefecto(string numeroOrdenProduccion, string tipoDefecto, string nombreDefecto,
            string orientacion, int cantidad, string nombreUsuario)
        {
            DateTime horaActual = DateTime.Now;
            List<TipoTurno> tiposTurno = repositorio.ObtenerTiposTurno();
            OrdenProduccion ordenProduccion = repositorio.ObtenerOrdenProduccion(numeroOrdenProduccion);
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
                Empleado supervisorCalidad = repositorio.ObtenerUsuario(nombreUsuario).Empleado;
                Defecto defecto = repositorio.ObtenerDefecto(tipoDefecto, nombreDefecto);
                Boolean existeEstadoEnCurso = ordenProduccion.VerificarEstadoEnCurso();

                if (existeEstadoEnCurso)
                {
                    Boolean existeBloqueTrabajo = ordenProduccion.VerificarExistenciaBloqueTrabajo(horaActual);

                    if (!existeBloqueTrabajo && cantidad == 1)
                    {
                        ordenProduccion.CrearBloqueTrabajo(horaActual, defecto, orientacion, supervisorCalidad);
                    }
                    else if (!existeBloqueTrabajo && cantidad == -1)
                    {
                        Console.WriteLine("La cantidad de defectos registrados en el bloque de trabajo actual es 0.");
                    }
                    else if (existeBloqueTrabajo && cantidad == 1)
                    {
                        ordenProduccion.RegistrarDefecto(defecto, orientacion);
                    }
                    else if(existeBloqueTrabajo && cantidad == -1)
                    {
                        ordenProduccion.QuitarDefecto(defecto, orientacion);
                    }
                }
                else
                {
                    Console.WriteLine("La orden de producción no se encuentra en curso.");
                }
            }
            else
            {
                Console.WriteLine("Ningún turno se encuentra en curso.");
            }

            return ordenProduccion;
        }
    }
}
