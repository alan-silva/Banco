using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // GravarUsandoAdoNet();
           // GravarUsandoEnntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            //Console.ReadLine();
            AtualizarProduto();
            Console.ReadLine();

        }

        private static void AtualizarProduto()
        {
            // Incluir um produto 
            // Pegar o produto e atualiza-lo
            GravarUsandoEnntity();
            RecuperarProdutos();
            // Atualiza o produto
           using (var repo = new ProdutoDAOEntity())
            {
              Produto primeiro = repo.Produtos().First();
                primeiro.Nome = "Cassino Royale - Editado ";
                repo.Atualizar(primeiro);
            }
            RecuperarProdutos();


           
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                foreach ( var item in produtos)
                {
                    repo.Remover(item); // Primeiro Removo do contexto
                    
                }

                 // Após Remover eu salvo as mudanças
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos(); // Select no banco precisa dessa classe 
                Console.WriteLine("Foram encontradas {0} produto(s).", produtos.Count);
                foreach ( var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoEnntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;



            Produto p1 = new Produto();
            p.Nome = "Todo Mundo em Pânico 2 ";
            p.Categoria = "Filmes";
            p.Preco = 19.90;

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
           
                // contexto.SaveChanges(); Não preciso no Entity
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
