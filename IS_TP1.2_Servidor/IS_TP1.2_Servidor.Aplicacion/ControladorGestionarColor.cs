using IS_TP1._2_Servidor.Datos;
using IS_TP1._2_Servidor.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Aplicacion
{
    public class ControladorGestionarColor
    {
        private Repositorio repositorio;

        public ControladorGestionarColor()
        {
            repositorio = Repositorio.ObtenerInstancia();
        }


        public Color ObtenerColor(string Codigo)
		{
            int i = 0;
            int index = 0;
            Boolean b = false;
            List<Color> colores = repositorio.ObtenerColores();
            foreach (Color c in colores)
            {
                if (c.Codigo == Codigo)
                {
                    index = i;
                    b = true;
                    break;
                }
                i++;
            }

            if (b)
            {
                return colores[index];
            }
            else
            {
                return null;
            }
        }

        public List<Color> ObtenerColores()
		{
            return repositorio.ObtenerColores();
		}

        public List<Color> CrearColor(string Codigo, string Descripcion)
        {
            Boolean b = false;
            List<Color> colores = repositorio.ObtenerColores();
            foreach (Color c in colores)
            {
                if (c.Codigo == Codigo)
                {
                    b = true;
                }
            }

            if (!b)
            {
                Color Color = new Color(Codigo, Descripcion);
                return repositorio.InsertarNuevoColor(Color);
            }
            else
            {
                return null;
            }
            
        }

        public List<Color> EliminarColor(string Codigo)
        {
            int i = 0;
            int index = 0;
            Boolean b = false;
            List<Color> colores = repositorio.ObtenerColores();
            foreach (Color c in colores)
			{
                if (c.Codigo == Codigo)
                {
                    index = i;
                    b = true;
                    break;
                }
                i++;
            }

			if (b)
			{
                colores.RemoveAt(index);
                return colores;
			}
			else
			{
                return null;
			}
        }

        public List<Color> ModificarColor(string Codigo, string Descripcion)
		{
            int i = 0;
            int index = 0;
            Boolean b = false;
            List<Color> colores = repositorio.ObtenerColores();
			foreach(Color c in colores)
			{
                if (c.Codigo == Codigo)
                {
                    index = i;
                    b = true;
                    break;
				}
                i++;
			}

            if (b)
			{
                colores[index].Descripcion = Descripcion;
                return colores;
			}
			else
			{
                return null;
			}
        }


	}
}
