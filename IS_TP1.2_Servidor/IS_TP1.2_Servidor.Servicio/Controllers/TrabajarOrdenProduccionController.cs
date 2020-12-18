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
    public class TrabajarOrdenProduccionController : ApiController
    {
        [Route("api/TrabajarOrdenProduccion/IncorporarseOrdenProduccion/")]
        [HttpPost]
        public OrdenProduccion IncorporarseOrdenProduccion([FromBody] JObject data)
        {
            ControladorTrabajarOrdenProduccion controladorTrabajarOrdenProduccion = new ControladorTrabajarOrdenProduccion();
            return controladorTrabajarOrdenProduccion.IncorporarseOrdenProduccion(data["numeroOrdenProduccion"].ToString(), data["nombreUsuario"].ToString());
        }

        [Route("api/TrabajarOrdenProduccion/AbandonarOrdenProduccion/")]
        [HttpPost]
        public List<OrdenProduccion> AbandonarOrdenProduccion([FromBody] JObject data)
        {
            ControladorTrabajarOrdenProduccion controladorTrabajarOrdenProduccion = new ControladorTrabajarOrdenProduccion();
            return controladorTrabajarOrdenProduccion.AbandonarOrdenProduccion(data["numeroOrdenProduccion"].ToString());
        }
    }
}
