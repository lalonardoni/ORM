using MeuProjeto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new VendasContext())
            {
                var produto = new Produto()
                {
                    Nome = "Bicicleta"
                };

                ctx.Produtos.Add(produto);
                ctx.SaveChanges();
            }
        }
    }
}
