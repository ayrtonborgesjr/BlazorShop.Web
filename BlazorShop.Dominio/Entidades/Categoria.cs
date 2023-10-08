using System.Collections.ObjectModel;
using Flunt.Br;

namespace BlazorShop.Dominio.Entidades;

public sealed class Categoria : Entidade
{
    public string Nome { get; private set; } = string.Empty;
    public string IconCss { get; private set; } = string.Empty;

    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    public Categoria()
    {
        
    }
    
    public Categoria(string nome, string iconCss) : base(Guid.NewGuid())
    {
        AtualizarNome(nome);
        AtualizarIconCss(iconCss);
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
    public void AtualizarIconCss(string novoIconCss)
    {
        AddNotifications(
            new Contract()
                .IsNotNullOrWhiteSpace(novoIconCss, "", "O iconCss não pode ser vazio")
                .IsGreaterOrEqualsThan(novoIconCss, 3, "", "O iconCss deve ter pelo menos 3 caracteres")
                .IsLowerOrEqualsThan(novoIconCss, 500, "", "O iconCss não pode ter mais de 500 caracteres")
        );
        IconCss = novoIconCss;
    }
}