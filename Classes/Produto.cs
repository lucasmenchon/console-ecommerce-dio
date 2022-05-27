using System;

namespace crud_dio
{
    public class Produto : EntidadeBase
    {
        // Atributos
		private Categoria Categoria { get; set; }
		private string Nome { get; set; }
		private string Descricao { get; set; }
		private double Preco { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Produto(int id, Categoria Categoria, string Nome, string descricao, double preco)
		{
			this.Id = id;
			this.Categoria = Categoria;
			this.Nome = Nome;
			this.Descricao = descricao;
			this.Preco = preco;
            this.Excluido = false;
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Categoria: " + this.Categoria + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descrição do Produto: " + this.Descricao + Environment.NewLine;
            retorno += "Preço: " + this.Preco + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaNome()
		{
			return this.Nome;
		}

		public double retornaPreco()
		{
			return this.Preco;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}