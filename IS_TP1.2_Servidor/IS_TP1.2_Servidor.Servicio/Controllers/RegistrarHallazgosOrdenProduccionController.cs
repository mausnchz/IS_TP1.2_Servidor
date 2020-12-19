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
            return controladorRegistrarHallazgosOrdenProduccion.GestionarDefecto(data["NumeroOrdenProduccion"].ToString(),
                data["TipoDefecto"].ToString(), data["NombreDefecto"].ToString(),
                data["Orientacion"].ToString(), int.Parse(data["Cantidad"].ToString()), data["NombreUsuario"].ToString());
        }

        [Route("api/RegistrarHallazgosOrdenProduccion/GestionarParPrimeraCalidad/")]
        [HttpPost]
        public OrdenProduccion GestionarParPrimeraCalidad([FromBody] JObject data)
        {
            ControladorRegistrarHallazgosOrdenProduccion controladorRegistrarHallazgosOrdenProduccion = new ControladorRegistrarHallazgosOrdenProduccion();
            return controladorRegistrarHallazgosOrdenProduccion.GestionarParPrimeraCalidad(data["NumeroOrdenProduccion"].ToString(), 
                int.Parse(data["Cantidad"].ToString()), data["NombreUsuario"].ToString());
        }

        [Route("api/RegistrarHallazgosOrdenProduccion/GestionarParesHermanados")]
        [HttpPost]
        public OrdenProduccion GestionarParesHermanados([FromBody] JObject data)
        {
            ControladorRegistrarHallazgosOrdenProduccion controladorRegistrarHallazgosOrdenProduccion = new ControladorRegistrarHallazgosOrdenProduccion();
            return controladorRegistrarHallazgosOrdenProduccion.GestionarParPrimeraCalidad(data["NumeroOrdenProduccion"].ToString(),
                int.Parse(data["Cantidad"].ToString()), data["NombreUsuario"].ToString());
        }
    }
}
