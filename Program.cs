using System;

namespace crud_dio
{
    class Program
    {
        static ProdutoRepositorio repositorio = new ProdutoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarProdutos();
						break;
					case "2":
						InserirProduto();
						break;
					case "3":
						AtualizarProduto();
						break;
					case "4":
						ExcluirProduto();
						break;
					case "5":
						VisualizarProduto();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado !");
			Console.ReadLine();
        }

        private static void ExcluirProduto()
		{
			Console.Write("Digite o id da Produto: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceProduto);
		}

        private static void VisualizarProduto()
		{
			Console.Write("Digite o id da Produto: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			var Produto = repositorio.RetornaPorId(indiceProduto);

			Console.WriteLine(Produto);
		}

        private static void AtualizarProduto()
		{
			Console.Write("Digite o id do Produto: ");
			int indiceProduto = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Categoria)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
			}
			Console.Write("Digite a Categoria entre as opções acima: ");
			int entradaCategoria = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da Produto: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Valor do Produto: ");
			double entradaPreco = double.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Produto: ");
			string entradaDescricao = Console.ReadLine();

			Produto atualizaProduto = new Produto(id: indiceProduto,
										Categoria: (Categoria)entradaCategoria,
										Nome: entradaNome,
										preco: entradaPreco,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceProduto, atualizaProduto);
		}
        private static void ListarProdutos()
		{
			Console.WriteLine("Listar Produtos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma Produto cadastrada.");
				return;
			}

			foreach (var Produto in lista)
			{
                var excluido = Produto.retornaExcluido();
                
				Console.WriteLine("#ID {0} Nome:{1} Preço: {2}", Produto.retornaId(), Produto.retornaNome(), Produto.retornaPreco(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirProduto()
		{
			Console.WriteLine("Inserir novo Produto");

			foreach (int i in Enum.GetValues(typeof(Categoria)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
			}
			Console.Write("Digite a Categoria entre as opções acima: ");
			int entradaCategoria = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome da Produto: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Preço do Produto: ");
			double entradaPreco = double.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Produto: ");
			string entradaDescricao = Console.ReadLine();

			Produto novoProduto = new Produto(id: repositorio.ProximoId(),
										Categoria: (Categoria)entradaCategoria,
										Nome: entradaNome,
										preco: entradaPreco,
										descricao: entradaDescricao);

			repositorio.Insere(novoProduto);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Produtos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Produtos");
			Console.WriteLine("2- Inserir novo Produto");
			Console.WriteLine("3- Atualizar Produto");
			Console.WriteLine("4- Excluir Produto");
			Console.WriteLine("5- Visualizar Produto");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
