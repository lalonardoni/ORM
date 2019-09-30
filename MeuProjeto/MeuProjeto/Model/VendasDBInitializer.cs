using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjeto.Model
{
    public class VendasDBInitializer : CreateDatabaseIfNotExists<VendasContext>
    {
        protected override void Seed(VendasContext context)
        {
            base.Seed(context);
        }
    }
}
