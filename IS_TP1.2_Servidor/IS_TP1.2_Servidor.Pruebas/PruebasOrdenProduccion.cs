using System;
using System.Collections.Generic;
using IS_TP1._2_Servidor.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IS_TP1._2_Servidor.Pruebas
{
    [TestClass]
    public class PruebasOrdenProduccion
    {
        [TestMethod]
        public void VerificarIncorporacionSupervisorCalidadDevuelveVerdaderoCuandoHaySupervisorIncorporado()
        {
            OrdenProduccion ordenProduccion = new OrdenProduccion();
            Empleado supervisorCalidad = new Empleado();
            ordenProduccion.SupervisorCalidadIncorporado = supervisorCalidad;

            Assert.AreEqual(true, ordenProduccion.VerificarIncorporacionSupervisorCalidad());
        }

        [TestMethod]
        public void VerificarIncorporacionSupervisorCalidadDevuelveFalsoCuandoNoHaySupervisorIncorporado()
        {
            OrdenProduccion ordenProduccion = new OrdenProduccion();

            Assert.AreEqual(false, ordenProduccion.VerificarIncorporacionSupervisorCalidad());
        }

        [TestMethod]
        public void VerificarEstadoEnCursoDevuelveVerdaderoCuandoLaOrdenDeProduccionEstaEnCurso()
        {
            OrdenProduccion ordenProduccion = new OrdenProduccion();
            ordenProduccion.Estado = EstadoOrdenProduccion.EN_CURSO;

            Assert.AreEqual(true, ordenProduccion.VerificarEstadoEnCurso());
        }

        [TestMethod]
        public void VerificarEstadoEnCursoDevuelveFalsoCuandoLaOrdenDeProduccionNoEstaEnCurso()
        {
            OrdenProduccion ordenProduccion = new OrdenProduccion();
            ordenProduccion.Estado = EstadoOrdenProduccion.FINALZIADA;

            Assert.AreEqual(false, ordenProduccion.VerificarEstadoEnCurso());
        }

        [TestMethod]
        public void VerificarExistenciaTurnoDevuelveVerdaderoCuandoElTurnoExiste()
        {
            OrdenProduccion ordenProduccion = new OrdenProduccion();
            DateTime horaActual = DateTime.Now;
            TipoTurno tipoTurno = new TipoTurno("Tarde", new DateTime(2020, 12, 12, 13, 0, 0), new DateTime(2020, 12, 12, 18, 0, 0));            
            
            List<Turno> turnos = new List<Turno>()
            {
                new Turno(DateTime.Now, tipoTurno, 10, 10, new List<BloqueTrabajo>()),
            };
            
            ordenProduccion.Turnos = turnos;

            Assert.AreEqual(true, ordenProduccion.VerificarExistenciaTurno(horaActual, tipoTurno));
        }

        [TestMethod]
        public void VerificarExistenciaTurnoDevuelveFalsoCuandoElTurnoNoExiste()
        {
            OrdenProduccion ordenProduccion = new OrdenProduccion();
            DateTime horaActual = DateTime.Now;
            TipoTurno tipoTurno = new TipoTurno("Mañana", new DateTime(2020, 12, 12, 8, 0, 0), new DateTime(2020, 12, 12, 12, 0, 0));
            TipoTurno otroTipoTurno = new TipoTurno("Tarde", new DateTime(2020, 12, 12, 14, 0, 0), new DateTime(2020, 12, 12, 18, 0, 0));

            List<Turno> turnos = new List<Turno>()
            {
                new Turno(DateTime.Now, tipoTurno, 10, 10, new List<BloqueTrabajo>()),
            };

            ordenProduccion.Turnos = turnos;

            Assert.AreEqual(false, ordenProduccion.VerificarExistenciaTurno(horaActual, otroTipoTurno));
        }
    }
}
