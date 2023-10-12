using BlazorShop.Dominio.Entidades;

namespace BlazorShop.Dominio.Contratos.Repositorios;

public interface IProdutoRepositorio : IRepositorio<Produto>
{
    Task<dynamic> Buscar(Filtro<Produto> filtro);
    Task Inserir(Produto produto);
    Task Atualizar(Produto produto);
    Task Excluir(Produto produto);
    Task<Produto?> BuscarProduto(Guid chave);
    Task<Produto?> BuscarProduto(int id);
    Task<IEnumerable<Produto>> BuscarItensPorCategoria(int id);

    Task<IEnumerable<Produto>> ListarProdutosDetalhado();
}