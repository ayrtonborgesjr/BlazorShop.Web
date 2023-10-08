using Flunt.Br;

namespace BlazorShop.Dominio.Entidades
{
	public sealed class Produto : Entidade
	{
		public string Nome { get; private set; } = string.Empty;
		public string Descricao { get; private set; } = string.Empty;
		public string ImagemUrl { get; private set; } = string.Empty;
		public decimal Preco { get; private set; }
		public int Quantidade { get; private set; }

		public int CategoriaId { get; set; }
		public Categoria? Categoria { get; set; }

		public ICollection<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();

		public Produto()
		{
			
		}

		public Produto(string nome, string descricao, string imagemUrl, decimal preco, int quantidade, int categoriaId) : base(Guid.NewGuid())
		{
			AtualizarNome(nome);
			AtualizarDescricao(descricao);
			ImagemUrl = imagemUrl;
			Preco = preco;
			Quantidade = quantidade;
			CategoriaId = categoriaId;
		}
		
		public void AtualizarNome(string novoNome)
		{
			AddNotifications(
				new Contract()
					.IsNotNullOrWhiteSpace(novoNome, "", "O nome da não pode ser vazio")
					.IsGreaterOrEqualsThan(novoNome, 3, "", "O nome deve ter pelo menos 3 caracteres")
					.IsLowerOrEqualsThan(novoNome, 100, "", "O nome não pode ter mais de 100 caracteres")
			);
			Nome = novoNome;
		}
		public void AtualizarDescricao(string novaDescricao)
		{
			AddNotifications(
				new Contract()
					.IsNotNullOrWhiteSpace(novaDescricao, "", "A descrição não pode ser vazia")
					.IsGreaterOrEqualsThan(novaDescricao, 3, "", "O descrição deve ter pelo menos 3 caracteres")
					.IsLowerOrEqualsThan(novaDescricao, 500, "", "O descrição não pode ter mais de 500 caracteres")
			);
			Descricao = novaDescricao;
		}
	}
}
