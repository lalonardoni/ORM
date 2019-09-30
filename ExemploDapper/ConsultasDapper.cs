using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace ExemploDapper
{
    class Program2
    {
        static void Teste(string[] args)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-9H7QD14\SQLEXPRESS;Initial Catalog=AdventureWorks2016;Integrated Security=true");
            conexao.Open();
            SqlMapper.GridReader multi = conexao.QueryMultiple(@"Select ProductNumber as Codigo,
                                                                         Name as DescricaoProduto,
                                                                         ListPrice as Preco
                                                                    from Production.Product
                                                                    where ListPrice between @PrecoMinimo and @PrecoMaximo
                                                                      and Name like @Descricao
                                                                      
                                                                      Select Name as DescricaoCategoria from Production.ProductCategory;", 
                                                                    new { PrecoMinimo = 0, 
                                                                          PrecoMaximo = 2000,
                                                                          Descricao = "%Red%"});

            IEnumerable<Produto> produtos = multi.Read<Produto>();
            IEnumerable<CategoriaProduto> categorias = multi.Read<CategoriaProduto>();
            
            foreach(Produto produto in produtos)
            {
                Console.WriteLine("{0} - {1} - {2}", produto.Codigo, produto.DescricaoProduto, produto.Preco);
            }

            Console.WriteLine("Categorias");           
            foreach(CategoriaProduto categoria in categorias)
            {
                Console.WriteLine("{0}", categoria.DescricaoCategoria);
            }
            
            conexao.Close();
        }
    }
}
