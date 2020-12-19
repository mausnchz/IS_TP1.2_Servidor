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
    public class AdministrarOrdenProduccionController : ApiController
    {
        [Route("api/AdministrarOrdenProduccion/ObtenerOrdenesProduccion")]
        [HttpGet]
        public List<OrdenProduccion> ObtenerOrdenesProduccion()
        {
            ControladorAdministrarOrdenProduccion controladorAdministrarOrdenProduccion = new ControladorAdministrarOrdenProduccion();
            return controladorAdministrarOrdenProduccion.ObtenerOrdenesProduccion();
        }

        [Route("api/AdministrarOrdenProduccion/ObtenerOrdenProduccion/{numeroOrdenProduccion}")]
        [HttpGet]
        public OrdenProduccion ObtenerOrdenesProduccion(string numeroOrdenProduccion)
        {
            ControladorAdministrarOrdenProduccion controladorAdministrarOrdenProduccion = new ControladorAdministrarOrdenProduccion();
            return controladorAdministrarOrdenProduccion.ObtenerOrdenProduccion(numeroOrdenProduccion);
        }

        [Route("api/AdministrarOrdenProduccion/RegistrarPausaOrdenProduccion")]
        [HttpPost]
        public List<OrdenProduccion> RegistrarPausaOrdenProduccion([FromBody] JObject data)
        {
            ControladorAdministrarOrdenProduccion controladorAdministrarOrdenProduccion = new ControladorAdministrarOrdenProduccion();
            return controladorAdministrarOrdenProduccion.RegistrarPausaOrdenProduccion(data["NumeroOrdenProduccion"].ToString());
        }

        [Route("api/AdministrarOrdenProduccion/RegistrarReanudacionOrdenProduccion")]
        [HttpPost]
        public List<OrdenProduccion> RegistrarReanudacionOrdenProduccion([FromBody] JObject data)
        {
            ControladorAdministrarOrdenProduccion controladorAdministrarOrdenProduccion = new ControladorAdministrarOrdenProduccion();
            return controladorAdministrarOrdenProduccion.RegistrarReanudacionOrdenProduccion(data["NumeroOrdenProduccion"].ToString());
        }

        [Route("api/AdministrarOrdenProduccion/RegistrarFinalizacionOrdenProduccion")]
        [HttpPost]
        public List<OrdenProduccion> RegistrarFinalizacionOrdenProduccion([FromBody] JObject data)
        {
            ControladorAdministrarOrdenProduccion controladorAdministrarOrdenProduccion = new ControladorAdministrarOrdenProduccion();
            return controladorAdministrarOrdenProduccion.RegistrarFinalizacionOrdenProduccion(data["NumeroOrdenProduccion"].ToString());
        }
    }
}
