using System.Linq.Expressions;
using BlazorShop.Dominio;
using BlazorShop.Dominio.Entidades;
using LinqKit;

namespace BlazorShop.Aplicacao.Filtros;

public class ProdutoFiltro : Filtro<Produto>
{
    public ProdutoFiltro()
    {
        OrdemPor = "Nome";
        Ordem = "asc";
    }

    public override Expression<Func<Produto, object>> Propriedades() =>
        a => new { a.Chave, a.Nome };

    public override Expression<Func<Produto, bool>> Consulta()
    {
        var consulta = PredicateBuilder.New<Produto>(a => true);

        if (!string.IsNullOrWhiteSpace(Busca))
            consulta.And(a =>
                a.Nome.Trim().ToLower().Equals(Busca.Trim().ToLower())
            );

        return consulta;
    }

}