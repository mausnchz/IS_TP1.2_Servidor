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
    public class TrabajarOrdenProduccionController : ApiController
    {
        [Route("api/TrabajarOrdenProduccion/IncorporarseOrdenProduccion/{numeroOrdenProduccion: string}/{nombreUsuario: string}")]
        [HttpPost]
        public OrdenProduccion IncorporarseOrdenProduccion(string numeroOrdenProduccion, string nombreUsuario)
        {
            ControladorTrabajarOrdenProduccion controladorTrabajarOrdenProduccion = new ControladorTrabajarOrdenProduccion();
            return controladorTrabajarOrdenProduccion.IncorporarseOrdenProduccion(numeroOrdenProduccion, nombreUsuario);
        }

        [Route("api/TrabajarOrdenProduccion/AbandonarOrdenProduccion/{numeroOrdenProduccion: string}")]
        [HttpPost]
        public List<OrdenProduccion> AbandonarOrdenProduccion(string numeroOrdenProduccion)
        {
            ControladorTrabajarOrdenProduccion controladorTrabajarOrdenProduccion = new ControladorTrabajarOrdenProduccion();
            return controladorTrabajarOrdenProduccion.AbandonarOrdenProduccion(numeroOrdenProduccion);
        }
    }
}
