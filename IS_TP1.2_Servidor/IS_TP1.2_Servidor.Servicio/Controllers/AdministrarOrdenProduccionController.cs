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
    public class AdministrarOrdenProduccionController : ApiController
    {
        [Route("api/AdministrarOrdenProduccion/RegistrarPausaOrdenProduccion/{numeroOrdenProduccion}")]
        [HttpPost]
        public List<OrdenProduccion> RegistrarPausaOrdenProduccion(string numeroOrdenProduccion)
        {
            ControladorAdministrarOrdenProduccion controladorAdministrarOrdenProduccion = new ControladorAdministrarOrdenProduccion();
            return controladorAdministrarOrdenProduccion.RegistrarPausaOrdenProduccion(numeroOrdenProduccion);
        }

        [Route("api/AdministrarOrdenProduccion/RegistrarReanudacionOrdenProduccion/{numeroOrdenProduccion}")]
        [HttpPost]
        public List<OrdenProduccion> RegistrarReanudacionOrdenProduccion(string numeroOrdenProduccion)
        {
            ControladorAdministrarOrdenProduccion controladorAdministrarOrdenProduccion = new ControladorAdministrarOrdenProduccion();
            return controladorAdministrarOrdenProduccion.RegistrarReanudacionOrdenProduccion(numeroOrdenProduccion);
        }

        [Route("api/AdministrarOrdenProduccion/RegistrarFinalizacionOrdenProduccion/{numeroOrdenProduccion}")]
        [HttpPost]
        public List<OrdenProduccion> RegistrarFinalizacionOrdenProduccion(string numeroOrdenProduccion)
        {
            ControladorAdministrarOrdenProduccion controladorAdministrarOrdenProduccion = new ControladorAdministrarOrdenProduccion();
            return controladorAdministrarOrdenProduccion.RegistrarFinalizacionOrdenProduccion(numeroOrdenProduccion);
        }
    }
}
