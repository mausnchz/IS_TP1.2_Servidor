using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Datos
{
    public class Repositorio<TEntity> : IDisposable
        where TEntity : class
    {
        private readonly Contexto contexto;

        public Repositorio()
        {
            if(contexto == null)
            {
                contexto = new Contexto();
            }
        }

        public IEnumerable<TEntity> ObtenerTodos()
        {
            return contexto.Set<TEntity>();
        }

        public IEnumerable<TEntity> ObtenerPorFiltro(Expression<Func<TEntity, bool>> filtro)
        {
            return contexto.Set<TEntity>().Where(filtro);
        }

        public void Agregar(TEntity entidad)
        {
            contexto.Set<TEntity>().Add(entidad);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void GuardarCambios()
        {
            contexto.SaveChanges();
        }
    }
}
