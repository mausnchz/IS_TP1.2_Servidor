using IS_TP1._2_Servidor.Datos;
using IS_TP1._2_Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Aplicacion
{
    public class ControladorGestionarModelo
    {
        private Repositorio repositorio;

        public ControladorGestionarModelo()
        {
            repositorio = Repositorio.ObtenerInstancia();
        }


        public Modelo ObtenerModelo(string SKU)
		{
            int i = 0;
            int index = 0;
            Boolean b = false;
            List<Modelo> modelos = repositorio.ObtenerModelos();
            foreach (Modelo m in modelos)
            {
                if (m.SKU == SKU)
                {
                    index = i;
                    b = true;
                    break;
                }
                i++;
            }

            if (b)
            {
                return modelos[index];
            }
            else
            {
                return null;
            }
        }

        public List<Modelo> ObtenerModelos()
		{
            return repositorio.ObtenerModelos();
		}

        public List<Modelo> CrearModelo(string SKU, string Denominacion, int Objetivo)
        {
            Boolean b = false;
            List<Modelo> modelos = repositorio.ObtenerModelos();
            foreach (Modelo m in modelos)
            {
                if (m.SKU == SKU)
                {
                    b = true;
                }
            }

            if (!b)
            {
                Modelo modelo = new Modelo(SKU, Denominacion, Objetivo);
                return repositorio.InsertarNuevoModelo(modelo);
            }
            else
            {
                return null;
            }
            
        }

        public List<Modelo> EliminarModelo(string SKU)
        {
            int i = 0;
            int index = 0;
            Boolean b = false;
            List<Modelo> modelos = repositorio.ObtenerModelos();
            foreach (Modelo m in modelos)
			{
                if (m.SKU == SKU)
                {
                    index = i;
                    b = true;
                    break;
                }
                i++;
            }

			if (b)
			{
                modelos.RemoveAt(index);
                return modelos;
			}
			else
			{
                return null;
			}
        }

        public List<Modelo> ModificarModelo(string SKU, string Denominacion, int Objetivo)
		{
            int i = 0;
            int index = 0;
            Boolean b = false;
            List<Modelo> modelos = repositorio.ObtenerModelos();
			foreach(Modelo m in modelos)
			{
                if (m.SKU == SKU)
                {
                    index = i;
                    b = true;
                    break;
				}
                i++;
			}

            if (b)
			{
                modelos[index].Denominacion = Denominacion;
                modelos[index].Objetivo = Objetivo;
                return modelos;
			}
			else
			{
                return null;
			}
        }


	}
}
