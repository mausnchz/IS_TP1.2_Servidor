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

        public void IncorporarSupervisorCalidad(Empleado supervisorCalidad)
        {
            SupervisorCalidadIncorporado = supervisorCalidad;
        }

        public Boolean VerificarExistenciaTurno(DateTime horaActual, TipoTurno tipoTurno)
        {
            foreach(Turno t in Turnos)
            {
                if(t.Fecha == horaActual.Date && t.Tipo == tipoTurno)
                {
                    return true;
                }
            }

            return false;
        }

        public void CrearTurno(DateTime horaActual, TipoTurno tipoTurno, Empleado supervisorCalidad)
        {
            Turno turno = new Turno(horaActual, tipoTurno, supervisorCalidad);
            Turnos.Add(turno);
        }

        public Boolean VerificarExistenciaBloqueTrabajo(DateTime horaActual)
        {
            Turno ultimoTurno = Turnos.Last();
            BloqueTrabajo ultimoBloqueTrabajo = ultimoTurno.BloquesTrabajo.Last();

            if(ultimoBloqueTrabajo.Hora == horaActual.Hour)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CrearBloqueTrabajo(DateTime horaActual, Empleado supervisorCalidad)
        {
            Turno ultimoTurno = Turnos.Last();
            ultimoTurno.CrearBloqueTrabajo(horaActual, supervisorCalidad);
        }
    }
}
