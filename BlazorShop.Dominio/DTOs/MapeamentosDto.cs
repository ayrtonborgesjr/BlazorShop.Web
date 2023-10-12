using BlazorShop.Dominio.DTOs;
using BlazorShop.Dominio.Entidades;

namespace BlazorShop.Dominio.DTOs;
    
public static class MapeamentosDto
{
    public static IEnumerable<CategoriaDto> ConverterCategoriasParaDto(this IEnumerable<Categoria> categorias)
    {
        return (from categoria in categorias
            select new CategoriaDto
            {
                Id = categoria.Id,
                Chave = categoria.Chave,
                Nome = categoria.Nome,
                IconCss = categoria.IconCss
            }).ToList();
    }

    public static IEnumerable<ProdutoDto> ConverterProdutosParaDto(this IEnumerable<Produto> produtos)
    {
        return (from produto in produtos
            select new ProdutoDto
            {
                Id = produto.Id,
                Chave = produto.Chave,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                ImagemUrl = produto.ImagemUrl,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                CategoriaId = produto.CategoriaId,
                CategoriaNome = produto.Categoria.Nome
            }).ToList();
    }

    public static ProdutoDto ConverterProdutoParaDto(this Produto produto)
    {
        return new ProdutoDto
        {
            Id = produto.Id,
            Chave = produto.Chave,
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            ImagemUrl = produto.ImagemUrl,
            Preco = produto.Preco,
            Quantidade = produto.Quantidade,
            CategoriaId = produto.CategoriaId,
            CategoriaNome = produto.Categoria.Nome
        };
    }

    public static IEnumerable<CarrinhoItemDto> ConverterCarrinhoItensParaDtos(
        this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
    {
        return (from carrinhoItem in carrinhoItens
            join produto in produtos
                on carrinhoItem.ProdutoId equals produto.Id
            select new CarrinhoItemDto
            {
                Id = carrinhoItem.Id,
                ProdutoId = carrinhoItem.ProdutoId,
                ProdutoNome = produto.Nome,
                ProdutoDescricao = produto.Descricao,
                ProdutoImagemUrl = produto.ImagemUrl,
                Preco = produto.Preco,
                CarrinhoId = carrinhoItem.CarrinhoId,
                Quantidade = carrinhoItem.Quantidade,
                PrecoTotal = produto.Preco * carrinhoItem.Quantidade
            }).ToList();
    }

    public static CarrinhoItemDto ConverterCarrinhoItemParaDtos(
        this CarrinhoItem carrinhoItem, Produto produto)
    {
        return new CarrinhoItemDto
        {
            Id = carrinhoItem.Id,
            ProdutoId = carrinhoItem.ProdutoId,
            ProdutoNome = produto.Nome,
            ProdutoDescricao = produto.Descricao,
            ProdutoImagemUrl = produto.ImagemUrl,
            Preco = produto.Preco,
            CarrinhoId = carrinhoItem.CarrinhoId,
            Quantidade = carrinhoItem.Quantidade,
            PrecoTotal = produto.Preco * carrinhoItem.Quantidade
        };
    }
}