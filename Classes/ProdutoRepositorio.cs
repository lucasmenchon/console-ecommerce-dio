using System;
using System.Collections.Generic;
using crud_dio.Interfaces;

namespace crud_dio
{
	public class ProdutoRepositorio : IRepositorio<Produto>
	{
        private List<Produto> listaProduto = new List<Produto>();
		public void Atualiza(int id, Produto objeto)
		{
			listaProduto[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaProduto[id].Excluir();
		}

		public void Insere(Produto objeto)
		{
			listaProduto.Add(objeto);
		}

		public List<Produto> Lista()
		{
			return listaProduto;
		}

		public int ProximoId()
		{
			return listaProduto.Count;
		}

		public Produto RetornaPorId(int id)
		{
			return listaProduto[id];
		}
	}
}