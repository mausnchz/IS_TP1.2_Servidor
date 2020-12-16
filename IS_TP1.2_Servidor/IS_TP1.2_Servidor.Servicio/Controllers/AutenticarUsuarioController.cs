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
    public class AutenticarUsuarioController : ApiController
    {
        [Route("api/AutenticarUsuario/{nombre}/{contrasenia}")]
        [HttpGet]
        public Boolean RegistrarPausaOrdenProduccion(string nombre, string contrasenia)
        {
            ControladorAutenticarUsuario controladorAutenticarUsuario = new ControladorAutenticarUsuario();
            return controladorAutenticarUsuario.autenticarUsuario(nombre, contrasenia);        }

        
    }
}
