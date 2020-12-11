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
        // POST: api/TrabajarOrdenProduccion
        public OrdenProduccion Post([FromBody]string numeroOrdenProduccion, string nombreUsuario)
        {
            ControladorTrabajarOrdenProduccion controladorTrabajarOrdenProduccion = new ControladorTrabajarOrdenProduccion();
            return controladorTrabajarOrdenProduccion.ObtenerOrdenProduccion(numeroOrdenProduccion, nombreUsuario);
        }

        // PUT: api/TrabajarOrdenProduccion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TrabajarOrdenProduccion/5
        public void Delete(int id)
        {
        }
    }
}
