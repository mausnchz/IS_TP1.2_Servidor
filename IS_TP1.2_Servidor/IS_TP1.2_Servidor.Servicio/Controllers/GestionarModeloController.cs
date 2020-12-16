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
    public class GestionarModeloController : ApiController
    {
		[Route("api/GestionarModelo/ObtenerModelo/{SKU}")]
		[HttpGet]
		public Modelo ObtenerModelo(string SKU)
		{
			ControladorGestionarModelo controladorGestionarModelo = new ControladorGestionarModelo();
			return controladorGestionarModelo.ObtenerModelo(SKU);
		}

		[Route("api/GestionarModelo/ObtenerModelos/")]
		[HttpGet]
		public List<Modelo> ObtenerModelos()
		{
			ControladorGestionarModelo controladorGestionarModelo = new ControladorGestionarModelo();
			return controladorGestionarModelo.ObtenerModelos();
		}


		[Route("api/GestionarModelo/CrearNuevoModelo")]
        [HttpPost]
        public List<Modelo> CrearNuevoModelo([FromBody]JObject data)
        {
            ControladorGestionarModelo controladorGestionarModelo = new ControladorGestionarModelo();
            return controladorGestionarModelo.CrearModelo(data["SKU"].ToString(), data["Denominacion"].ToString(),int.Parse(data["Objetivo"].ToString()));
        }

		[Route("api/GestionarModelo/ModificarModelo")]
		[HttpPut]
		public List<Modelo> ModificarModelo([FromBody] JObject data)
		{
			ControladorGestionarModelo controladorGestionarModelo = new ControladorGestionarModelo();
			return controladorGestionarModelo.ModificarModelo(data["SKU"].ToString(), data["Denominacion"].ToString(), int.Parse(data["Objetivo"].ToString()));
		}

		[Route("api/GestionarModelo/EliminarModelo")]
		[HttpDelete]
		public List<Modelo> EliminarModel([FromBody] JObject data)
		{
			ControladorGestionarModelo controladorGestionarModelo = new ControladorGestionarModelo();
			return controladorGestionarModelo.EliminarModelo(data["Codigo"].ToString());
		}


	}
}
