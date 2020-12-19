using IS_TP1._2_Servidor.Aplicacion;
using IS_TP1._2_Servidor.Dominio;
using Newtonsoft.Json.Linq;
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
        [Route("api/RegistrarHallazgosOrdenProduccion/GestionarDefecto/")]
        [HttpPost]
        public OrdenProduccion GestionarDefecto([FromBody] JObject data)
        {
            ControladorRegistrarHallazgosOrdenProduccion controladorRegistrarHallazgosOrdenProduccion = new ControladorRegistrarHallazgosOrdenProduccion();
            return controladorRegistrarHallazgosOrdenProduccion.GestionarDefecto(data["numeroOrdenProduccion"].ToString(),
                data["tipoDefecto"].ToString(), data["nombreDefecto"].ToString(),
                data["orientacion"].ToString(), int.Parse(data["cantidad"].ToString()), data["nombreUsuario"].ToString());
        }

        [Route("api/RegistrarHallazgosOrdenProduccion/GestionarParPrimeraCalidad/" +
            "{cantidad}/{nombreUsuario}")]
        [HttpPost]
        public OrdenProduccion GestionarParPrimeraCalidad([FromBody] JObject data)
        {
            ControladorRegistrarHallazgosOrdenProduccion controladorRegistrarHallazgosOrdenProduccion = new ControladorRegistrarHallazgosOrdenProduccion();
            return controladorRegistrarHallazgosOrdenProduccion.GestionarParPrimeraCalidad(data["numeroOrdenProduccion"].ToString(), 
                int.Parse(data["cantidad"].ToString()), data["nombreUsuario"].ToString());
        }

        [Route("api/RegistrarHallazgosOrdenProduccion/GestionarParesHermanados")]
        [HttpPost]
        public OrdenProduccion GestionarParesHermanados([FromBody] JObject data)
        {
            ControladorRegistrarHallazgosOrdenProduccion controladorRegistrarHallazgosOrdenProduccion = new ControladorRegistrarHallazgosOrdenProduccion();
            return controladorRegistrarHallazgosOrdenProduccion.GestionarParPrimeraCalidad(data["numeroOrdenProduccion"].ToString(),
                int.Parse(data["cantidad"].ToString()), data["nombreUsuario"].ToString());
        }
    }
}
