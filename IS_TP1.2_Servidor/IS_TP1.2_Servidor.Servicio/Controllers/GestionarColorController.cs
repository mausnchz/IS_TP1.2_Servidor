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
    public class GestionarColorController : ApiController
    {
		[Route("api/GestionarColor/ObtenerColor/{Codigo}")]
		[HttpGet]
		public Color ObtenerColor(string Codigo)
		{
			ControladorGestionarColor controladorGestionarColor = new ControladorGestionarColor();
			return controladorGestionarColor.ObtenerColor(Codigo);
		}

		[Route("api/GestionarColor/ObtenerColores/")]
		[HttpGet]
		public List<Color> ObtenerColores()
		{
			ControladorGestionarColor controladorGestionarColor = new ControladorGestionarColor();
			return controladorGestionarColor.ObtenerColores();
		}


		[Route("api/GestionarColor/CrearNuevoColor")]
        [HttpPost]
        public List<Color> CrearNuevoColor([FromBody]JObject data)
        {
            ControladorGestionarColor controladorGestionarColor = new ControladorGestionarColor();
            return controladorGestionarColor.CrearColor(data["Codigo"].ToString(), data["Descripcion"].ToString());
        }

		[Route("api/GestionarColor/ModificarColor")]
		[HttpPut]
		public List<Color> ModificarColor([FromBody] JObject data)
		{
			ControladorGestionarColor controladorGestionarColor = new ControladorGestionarColor();
			return controladorGestionarColor.ModificarColor(data["Codigo"].ToString(), data["Descripcion"].ToString());
		}

		[Route("api/GestionarColor/EliminarColor")]
		[HttpDelete]
		public List<Color> EliminarColor([FromBody] JObject data)
		{
			ControladorGestionarColor controladorGestionarColor = new ControladorGestionarColor();
			return controladorGestionarColor.EliminarColor(data["Codigo"].ToString());
		}


	}
}
