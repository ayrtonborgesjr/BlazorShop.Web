using Flunt.Br;

namespace BlazorShop.Dominio.Entidades;

public sealed class Usuario : Entidade
{
    public string Nome { get; private set; } = string.Empty;
    public Carrinho? Carrinho { get; set; }

    public Usuario(string nome) : base(Guid.NewGuid())
    {
        AtualizarNome(nome);
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
}