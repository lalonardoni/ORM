using FluentApiExample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentApiExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new VendasContext())
            {
                var vendas = contexto.Vendas
            }
        }


        static void NovaVenda()
        {
            var cliente = new Cliente();

            cliente.Nome = "PEDRO";
            cliente.DataNascimento = new DateTime(2000, 12, 1);
            cliente.Cpf = "999.999.999-99";

            var produto = new Produto();
            produto.Codigo = "9999";
            produto.Descricao = "CAMISA NIKE";
            produto.Valor = 100;

            var itemVenda = new VendaItem();
            itemVenda.Produto = produto;
            itemVenda.Quantidade = 2;
            itemVenda.Desconto = 10;

            var venda = new Venda();
            venda.Cliente = cliente;
            venda.ItensDaVenda = new List<VendaItem>();
            venda.ItensDaVenda.Add(itemVenda);

            var contexto = new VendasContext();
            contexto.Vendas.Add(venda);

            contexto.SaveChanges();
        }
    }
}
