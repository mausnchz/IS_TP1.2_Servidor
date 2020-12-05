using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_TP1._2_Servidor.Datos
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=ControlCalidad")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<Entidad>()
            //    .HasKey(z => z.Valor);
        }

    }
}
