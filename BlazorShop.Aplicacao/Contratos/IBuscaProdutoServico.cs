using BlazorShop.Aplicacao.Filtros;
using BlazorShop.Dominio.DTOs;

namespace BlazorShop.Aplicacao.Contratos;

public interface IBuscaProdutoServico
{
    Task<dynamic> Buscar(ProdutoFiltro filtro);
    Task<ProdutoDto?> BuscarDetalhado(Guid chave);
    Task<ProdutoDto?> BuscarDetalhado(int id);
    Task<IEnumerable<ProdutoDto?>> ListarProdutosDetalhado();
}