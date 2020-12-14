using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class OrdenProduccion
    {
        public string Numero { get; set; }
        public Modelo Modelo { get; set; }
        public Color Color { get; set; }
        public EstadoOrdenProduccion Estado { get; set; }
        public Empleado SupervisorLinea { get; set; }
        public Empleado SupervisorCalidadIncorporado{ get; set; }
        public List<Turno> Turnos { get; set; }

        public OrdenProduccion() { }

        public OrdenProduccion(string numero, Modelo modelo, Color color, EstadoOrdenProduccion estadoOrdenProduccion,
            Empleado supervisorLinea, List<Turno> turnos)
        {
            this.Numero = numero;
            this.Modelo = modelo;
            this.Color = color;
            this.Estado = estadoOrdenProduccion;
            this.SupervisorLinea = supervisorLinea;
            this.Turnos = turnos;
        }

        public Boolean VerificarIncorporacionSupervisorCalidad()
        {
            if(SupervisorCalidadIncorporado != null)
            {
                return true;
            }

            return false;
        }

        public Boolean VerificarEstadoEnCurso()
        {
            if(Estado == EstadoOrdenProduccion.EN_CURSO)
            {
                return true;
            }

            return false;
        }

        public Boolean VerificarEstadoPausada()
        {
            if(Estado == EstadoOrdenProduccion.PAUSADA)
            {
                return true;
            }

            return false;
        }

        public Boolean VerificarEstadoNoFinalizado()
        {
            if(Estado!= EstadoOrdenProduccion.FINALZIADA)
            {
                return true;
            }
            return false;
        }

        public void IncorporarSupervisorCalidad(Empleado supervisorCalidad)
        {
            SupervisorCalidadIncorporado = supervisorCalidad;
        }

        public Boolean VerificarExistenciaTurno(DateTime horaActual, TipoTurno tipoTurno)
        {
            try
            {
                foreach (Turno t in Turnos)
                {
                    if (t.Fecha.Date == horaActual.Date && t.Tipo == tipoTurno)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public void CrearTurno(DateTime horaActual, TipoTurno tipoTurno, Empleado supervisorCalidad)
        {
            Turno turno = new Turno(horaActual, tipoTurno, supervisorCalidad);
            Turnos.Add(turno);
        }

        public Boolean VerificarExistenciaBloqueTrabajo(DateTime horaActual)
        {
            try
            {
                Turno ultimoTurno = Turnos.Last();
                BloqueTrabajo ultimoBloqueTrabajo = ultimoTurno.BloquesTrabajo.Last();

                if (ultimoBloqueTrabajo.Hora == horaActual.Hour)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public void CrearBloqueTrabajo(DateTime horaActual, Empleado supervisorCalidad)
        {
            Turno ultimoTurno = Turnos.Last();
            ultimoTurno.CrearBloqueTrabajo(horaActual, supervisorCalidad);
        }

        public void CrearBloqueTrabajo(DateTime horaActual, Defecto defecto, string orientacion, Empleado supervisorCalidad)
        {
            Turno ultimoTurno = Turnos.Last();
            ultimoTurno.CrearBloqueTrabajo(horaActual, defecto, orientacion, supervisorCalidad);
        }

        public void CrearBloqueTrabajoRegistrarParPrimeraCalidad(DateTime horaActual, Empleado supervisorCalidad)
        {
            Turno ultimoTurno = Turnos.Last();
            ultimoTurno.CrearBloqueTrabajoRegistrarParPrimeraCalidad(horaActual, supervisorCalidad);
        }

        public void RegistrarDefecto(Defecto defecto, string orientacion)
        {
            Turno ultimoTurno = Turnos.Last();
            ultimoTurno.RegistrarDefecto(defecto, orientacion);
        }

        public void QuitarDefecto(Defecto defecto, string orientacion)
        {
            Turno ultimoTurno = Turnos.Last();
            ultimoTurno.QuitarDefecto(defecto, orientacion);
        }

        public void RegistrarParPrimeraCalidad()
        {
            Turno ultimoTurno = Turnos.Last();
            ultimoTurno.RegistrarParPrimeraCalidad();
        }

        public void QuitarParPrimeraCalidad()
        {
            Turno ultimoTurno = Turnos.Last();
            ultimoTurno.QuitarParPrimeraCalidad();
        }

        public void LiberarSupervisorCalidad()
        {
            SupervisorCalidadIncorporado = null;
        }

        public void PausarOrdenProduccion()
        {
            Estado = EstadoOrdenProduccion.PAUSADA;
        }

        public void ReanudarOrdenProduccion()
        {
            Estado = EstadoOrdenProduccion.EN_CURSO;
        }

        public void FinalizarOrdenProduccion()
        {
            Estado = EstadoOrdenProduccion.FINALZIADA;
        }
    }
}
