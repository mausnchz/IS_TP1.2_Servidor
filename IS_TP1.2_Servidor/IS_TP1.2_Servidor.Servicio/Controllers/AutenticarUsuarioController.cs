using IS_TP1._2_Servidor.Aplicacion;
using IS_TP1._2_Servidor.Dominio;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace IS_TP1._2_Servidor.Servicio.Controllers
{
	public class AutenticarUsuarioController : ApiController
	{
		[Route("api/AutenticarUsuario")]
		[HttpPost]
		public Usuario RegistrarPausaOrdenProduccion([FromBody] JObject data)
		{
			ControladorAutenticarUsuario controladorAutenticarUsuario = new ControladorAutenticarUsuario();
			return controladorAutenticarUsuario.autenticarUsuario(data["Nombre"].ToString(), data["Contraseña"].ToString());

		}

	}
}
