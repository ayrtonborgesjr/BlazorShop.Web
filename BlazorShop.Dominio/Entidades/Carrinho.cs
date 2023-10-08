namespace BlazorShop.Dominio.Entidades;

public sealed class Carrinho : Entidade
{
    public int UsuarioId { get; private set; }
    
    public ICollection<CarrinhoItem> Itens { get; set; } = new List<CarrinhoItem>();

    public Carrinho()
    {
        
    }

    public Carrinho(int usuarioId) : base(Guid.NewGuid())
    {
        UsuarioId = usuarioId;
    }
}