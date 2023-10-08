using BlazorShop.Dominio;
using BlazorShop.Dominio.Entidades;
using System.Linq.Expressions;
using LinqKit;

namespace BlazorShop.Aplicacao.Filtros;

public sealed class UsuarioFiltro : Filtro<Usuario>
{
    public UsuarioFiltro()
    {
        OrdemPor = "Nome";
        Ordem = "asc";
    }
    
    public override Expression<Func<Usuario, object>> Propriedades() =>
        a => new { a.Chave, a.Nome };

    public override Expression<Func<Usuario, bool>> Consulta()
    {
        var consulta = PredicateBuilder.New<Usuario>(a => true);

        if (!string.IsNullOrWhiteSpace(Busca))
            consulta.And(a =>
                a.Nome.Trim().ToLower().Equals(Busca.Trim().ToLower())
            );

        return consulta;
    }
}