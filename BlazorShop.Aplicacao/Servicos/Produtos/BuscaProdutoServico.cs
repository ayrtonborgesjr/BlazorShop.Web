using BlazorShop.Aplicacao.Contratos;
using BlazorShop.Aplicacao.Filtros;
using BlazorShop.Dominio.Contratos.Repositorios;
using BlazorShop.Dominio.DTOs;

namespace BlazorShop.Aplicacao.Servicos.Produtos;

public sealed class BuscaProdutoServico : IBuscaProdutoServico
{
    private readonly IProdutoRepositorio _repositorio;

    public BuscaProdutoServico(IProdutoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<dynamic> Buscar(ProdutoFiltro filtro) => 
        await _repositorio.Buscar(filtro);


    public async Task<ProdutoDto?> Buscar(Guid? chave)
    {
        var produto = await _repositorio.Buscar(chave.GetValueOrDefault());

        return produto.ConverterProdutoParaDto();
    }

    public async Task<ProdutoDto?> BuscarDetalhado(Guid chave)
    {
        var produto = await _repositorio.BuscarProduto(chave);

        return produto.ConverterProdutoParaDto();
    }

    public async Task<ProdutoDto?> BuscarDetalhado(int id)
    {
        var produto = await _repositorio.BuscarProduto(id);

        return produto.ConverterProdutoParaDto();
    }

    public async Task<IEnumerable<ProdutoDto?>> ListarProdutosDetalhado()
    {
        var produtos = await _repositorio.ListarProdutosDetalhado();

        return produtos.ConverterProdutosParaDto();
    }
}