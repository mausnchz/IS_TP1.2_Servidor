using IS_TP1._2_Servidor.Aplicacion;
using IS_TP1._2_Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IS_TP1._2_Servidor.Servicio.Controllers
{
    public class RegistrarHallazgosOrdenProduccionController : ApiController
    {
        [Route("api/RegistrarHallazgosOrdenProduccion/GestionarDefecto/{numeroOrdenProduccion}/{tipoDefecto}/" +
            "{nombreDefecto}/{orientacion}/{cantidad: int}/{nombreUsuario}")]
        [HttpPost]
        public OrdenProduccion GestionarDefecto(string numeroOrdenProduccion, string tipoDefecto, string nombreDefecto,
            string orientacion, int cantidad, string nombreUsuario)
        {
            ControladorRegistrarHallazgosOrdenProduccion controladorRegistrarHallazgosOrdenProduccion = new ControladorRegistrarHallazgosOrdenProduccion();
            return controladorRegistrarHallazgosOrdenProduccion.GestionarDefecto(numeroOrdenProduccion, tipoDefecto, nombreDefecto,
                orientacion, cantidad, nombreUsuario);
        }
    }
}
