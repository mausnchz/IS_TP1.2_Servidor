using IS_TP1._2_Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Datos
{
    public sealed class BaseDatos
    {
        private static BaseDatos instancia;
        private List<BloqueTrabajo> bloquesTrabajo;
        private List<Cargo> cargos;
        private List<Color> colores;
        private List<Defecto> defectos;
        private List<DefectoRegistrado> defectosRegistrados;
        private List<Empleado> empleados;
        private List<Modelo> modelos;
        private List<OrdenProduccion> ordenesProduccion;
        private List<TipoDefecto> tiposDefecto;
        private List<TipoTurno> tiposTurno;
        private List<Turno> turnos;
        private List<Usuario> usuarios;
        private List<LineaTrabajo> lineasTrabajo;

        private BaseDatos()
        {
            bloquesTrabajo = new List<BloqueTrabajo>();
            cargos = new List<Cargo>();
            colores = new List<Color>();
            defectos = new List<Defecto>();
            defectosRegistrados = new List<DefectoRegistrado>();
            empleados = new List<Empleado>();
            modelos = new List<Modelo>();
            ordenesProduccion = new List<OrdenProduccion>();
            tiposDefecto = new List<TipoDefecto>();
            tiposTurno = new List<TipoTurno>();
            turnos = new List<Turno>();
            usuarios = new List<Usuario>();
            lineasTrabajo = new List<LineaTrabajo>();
            GenerarDatos();
        }

        public static BaseDatos ObtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new BaseDatos();
            }

            return instancia;
        }

        private void GenerarDatos()
        {
            GenerarColores();
            GenerarModelos();
            GenerarTiposTurno();
            GenerarCargos();
            GenerarTiposDefecto();
            GenerarEmpleados();
            GenerarUsuarios();
            GenerarDefectos();
            GenerarDefectosRegistrados();
            GenerarBloquesTrabajo();
            GenerarTurnos();
            GenerarOrdenesProduccion();
            GenerarLineasTrabajo();
        }

        public List<Modelo> InsertarNuevoModelo(Modelo modelo)
		{
            modelos.Add(modelo);
            return modelos;
		}

        public List<Color> InsertarNuevoColor(Color color)
        {
            colores.Add(color);
            return colores;
        }

        private void GenerarLineasTrabajo()
        {
            lineasTrabajo.Add(new LineaTrabajo("0001", new List<OrdenProduccion>(ordenesProduccion)));
        }

        public List<LineaTrabajo> ObtenerLineasTrabajo()
        {
            return lineasTrabajo;
        }

        public List<OrdenProduccion> ObtenerOrdenesProduccion()
        {
            return ordenesProduccion;
        }

        public List<Modelo> ObtenerModelos()
        {
            return modelos;
        }

        public List<Color> ObtenerColores()
        {
            return colores;
        }

        public List<TipoTurno> ObtenerTiposTurno()
        {
            return tiposTurno;
        }

        public List<Cargo> ObtenerCargos()
        {
            return cargos;
        }

        public List<TipoDefecto> ObtenerTiposDefecto()
        {
            return tiposDefecto;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return empleados;
        }

        public List<Defecto> ObtenerDefectos()
        {
            return defectos;
        }

        public List<DefectoRegistrado> ObtenerDefectosRegistrados()
        {
            return defectosRegistrados;
        }

        public List<BloqueTrabajo> ObtenerBloquesTrabajo()
        {
            return bloquesTrabajo;
        }

        public List<Turno> ObtenerTurnos()
        {
            return turnos;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        private void GenerarColores()
        {
            colores.Add(new Color("0001", "Azul"));
            colores.Add(new Color("0002", "Rojo"));
            colores.Add(new Color("0003", "Verde"));
            colores.Add(new Color("0004", "Morado"));
            colores.Add(new Color("0005", "Rosa"));
            colores.Add(new Color("0006", "Negro"));
        }

        private void GenerarModelos()
        {
            modelos.Add(new Modelo("0001", "Modelo No.1", 80));
            modelos.Add(new Modelo("0002", "Modelo No.2", 70));
            modelos.Add(new Modelo("0003", "Modelo No.3", 75));
            modelos.Add(new Modelo("0004", "Modelo No.4", 82));
            modelos.Add(new Modelo("0005", "Modelo No.5", 45));
            modelos.Add(new Modelo("0006", "Modelo No.6", 60));
        }

        private void GenerarTiposTurno()
        {
            tiposTurno.Add(new TipoTurno("Mañana", new DateTime(2020, 6, 15, 8, 0, 0), new DateTime(2020, 6, 15, 12, 0, 0)));
            tiposTurno.Add(new TipoTurno("Tarde", new DateTime(2020, 6, 15, 14, 0, 0), new DateTime(2020, 6, 15, 23, 59, 0)));
            tiposTurno.Add(new TipoTurno("Mañana", new DateTime(2020, 6, 15, 20, 0, 0), new DateTime(2020, 6, 15, 00, 0, 0)));
        }

        private void GenerarCargos()
        {
            cargos.Add(new Cargo("Administrativo"));
            cargos.Add(new Cargo("Supervisor de calidad"));
            cargos.Add(new Cargo("Supervisor de línea"));
        }

        private void GenerarTiposDefecto()
        {
            tiposDefecto.Add(new TipoDefecto("Observado"));
            tiposDefecto.Add(new TipoDefecto("Reproceso"));
        }

        private void GenerarEmpleados()
        {
            empleados.Add(new Empleado("Apellido", "Nombre", "40345498", "email@email.com", cargos[0]));
            empleados.Add(new Empleado("Apellido", "Nombre", "40345497", "email@email.com", cargos[1]));
            empleados.Add(new Empleado("Apellido", "Nombre", "40345496", "email@email.com", cargos[2]));
        }

        private void GenerarUsuarios()
        {
            usuarios.Add(new Usuario("administrativo", "1234", empleados[0]));
            usuarios.Add(new Usuario("supervisorCalidad", "contraseña", empleados[1]));
            usuarios.Add(new Usuario("supervisorLinea", "contraseña", empleados[2]));

        }

        private void GenerarDefectos()
        {
            defectos.Add(new Defecto("Defecto No.1", tiposDefecto[0]));
            defectos.Add(new Defecto("Defecto No.2", tiposDefecto[0]));
            defectos.Add(new Defecto("Defecto No.3", tiposDefecto[0]));
            defectos.Add(new Defecto("Defecto No.4", tiposDefecto[0]));
            defectos.Add(new Defecto("Defecto No.5", tiposDefecto[0]));
            defectos.Add(new Defecto("Defecto No.6", tiposDefecto[0]));
            defectos.Add(new Defecto("Defecto No.1", tiposDefecto[1]));
            defectos.Add(new Defecto("Defecto No.2", tiposDefecto[1]));
            defectos.Add(new Defecto("Defecto No.3", tiposDefecto[1]));
            defectos.Add(new Defecto("Defecto No.4", tiposDefecto[1]));
            defectos.Add(new Defecto("Defecto No.5", tiposDefecto[1]));
            defectos.Add(new Defecto("Defecto No.6", tiposDefecto[1]));
        }

        private void GenerarDefectosRegistrados()
        {
            defectosRegistrados.Add(new DefectoRegistrado(defectos[0], Orientacion.DERECHO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[1], Orientacion.IZQUIERDO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[2], Orientacion.DERECHO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[3], Orientacion.IZQUIERDO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[4], Orientacion.DERECHO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[5], Orientacion.IZQUIERDO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[6], Orientacion.DERECHO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[7], Orientacion.IZQUIERDO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[8], Orientacion.DERECHO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[9], Orientacion.IZQUIERDO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[10], Orientacion.DERECHO));
            defectosRegistrados.Add(new DefectoRegistrado(defectos[11], Orientacion.IZQUIERDO));
        }

        private void GenerarBloquesTrabajo()
        {
            bloquesTrabajo.Add(new BloqueTrabajo(8, 30, empleados[1], defectosRegistrados));
            bloquesTrabajo.Add(new BloqueTrabajo(9, 46, empleados[1], defectosRegistrados));
            bloquesTrabajo.Add(new BloqueTrabajo(10, 32, empleados[1], defectosRegistrados));
            bloquesTrabajo.Add(new BloqueTrabajo(11, 49, empleados[1], defectosRegistrados));
        }

        private void GenerarTurnos()
        {
            turnos.Add(new Turno(new DateTime(2020, 12, 10), tiposTurno[0], 12, 10, bloquesTrabajo));
            turnos.Add(new Turno(new DateTime(2020, 12, 11), tiposTurno[0], 11, 8, bloquesTrabajo));
            turnos.Add(new Turno(new DateTime(2020, 12, 12), tiposTurno[0], 16, 11, bloquesTrabajo));
        }

        private void GenerarOrdenesProduccion()
        {
            ordenesProduccion.Add(new OrdenProduccion("0001", modelos[0], colores[0], EstadoOrdenProduccion.EN_CURSO,
                empleados[2], turnos));
        }
    }
}
