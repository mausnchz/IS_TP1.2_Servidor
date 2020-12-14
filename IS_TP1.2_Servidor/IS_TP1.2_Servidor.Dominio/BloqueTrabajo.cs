using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Dominio
{
    public class BloqueTrabajo
    {
        public int Hora { get; set; }
        public int CantidadParesPrimeraCalidad { get; set; }
        public Empleado SupervisorCalidad { get; set; }
        public List<DefectoRegistrado> DefectosRegistrados { get; set; }

        public BloqueTrabajo(int hora, int cantidadParesPrimeraCalidad, Empleado supervisorCalidad,
            List<DefectoRegistrado> defectosRegistrados)
        {
            this.Hora = hora;
            this.CantidadParesPrimeraCalidad = cantidadParesPrimeraCalidad;
            this.SupervisorCalidad = supervisorCalidad;
            this.DefectosRegistrados = defectosRegistrados;
        }

        public BloqueTrabajo(DateTime horaActual, Defecto defecto, string orientacion, Empleado supervisorCalidad)
        {
            Hora = horaActual.Hour;
            SupervisorCalidad = supervisorCalidad;
            DefectosRegistrados = new List<DefectoRegistrado>();
            Orientacion orientacionEnumeracion = Orientacion.IZQUIERDO;
            orientacionEnumeracion = DeterminarOrientacion(orientacion);

            DefectoRegistrado defectoRegistrado = new DefectoRegistrado(defecto, orientacionEnumeracion);
            DefectosRegistrados.Add(defectoRegistrado);
        }

        private Orientacion DeterminarOrientacion(string orientacion)
        {
            Orientacion orientacionEnumeracion = Orientacion.DERECHO;
            
            if (orientacion.ToUpper() == "IZQUIERDO")
            {
                orientacionEnumeracion =  Orientacion.IZQUIERDO;
            }
            else if (orientacion.ToUpper() == "DERECHO")
            {
                orientacionEnumeracion = Orientacion.DERECHO;
            }

            return orientacionEnumeracion;
        }

        public BloqueTrabajo(DateTime horaActual, Empleado supervisorCalidad)
        {
            Hora = horaActual.Hour;
            SupervisorCalidad = supervisorCalidad;
            DefectosRegistrados = new List<DefectoRegistrado>();
        }

        public void RegistrarDefecto(Defecto defecto, string orientacion)
        {
            Orientacion orientacionEnumeracion = DeterminarOrientacion(orientacion);
            DefectoRegistrado defectoRegistrado = new DefectoRegistrado(defecto, orientacionEnumeracion);
            DefectosRegistrados.Add(defectoRegistrado);
        }

        public void QuitarDefecto(Defecto defecto, string orientacion)
        {
            Orientacion orientacionEnumeracion = DeterminarOrientacion(orientacion);
            DefectoRegistrado defectoRegistradoAQuitar = DefectosRegistrados.FirstOrDefault(z => z.Defecto.Descripcion == defecto.Descripcion &&
                z.Defecto.Tipo.Descripcion == defecto.Tipo.Descripcion);
            DefectosRegistrados.Remove(defectoRegistradoAQuitar);
        }
    }
}
