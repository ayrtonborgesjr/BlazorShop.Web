namespace BlazorShop.Dominio.Entidades;

public sealed class CarrinhoItem : Entidade
{
    public int CarrinhoId { get; private set; }
    public Carrinho? Carrinho { get; set; }
    public int ProdutoId { get; private set; }
    public Produto? Produto { get; set; }
    public int Quantidade { get; private set; }

    public CarrinhoItem()
    {
        
    }
    
    public CarrinhoItem(int carrinhoId, int produtoId, int quantidade) : base(Guid.NewGuid())
    {
        CarrinhoId = carrinhoId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
    }
}