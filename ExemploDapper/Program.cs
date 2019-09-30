using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace ExemploDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conexao = new SqlConnection(@"Data Source=DESKTOP-9H7QD14\SQLEXPRESS;Initial Catalog=VENDASAPP;Integrated Security=true");
            conexao.Open();

            string sql = "DELETE FROM PRODUTOS WHERE CODIGO = @CODIGO";
            int linhasAfetadas = conexao.Execute(sql, 
                new []
                {
                    new { CODIGO = "3" },
                    new { CODIGO = "6" }
                });

            IEnumerable<Produto> produtos = conexao.Query<Produto>(@"Select Codigo as Codigo,
                                                                           Descricao as DescricaoProduto,
                                                                           Valor as Preco
                                                                      from Produtos");

           
            foreach(Produto produto in produtos)
            {
                Console.WriteLine("{0} - {1} - {2}", produto.Codigo, produto.DescricaoProduto, produto.Preco);
            }
            
            conexao.Close();
        }
    }
}
