using BlazorShop.Dominio.Entidades;
using System.Linq.Expressions;

namespace BlazorShop.Dominio;

public abstract class Filtro<TEntidade> where TEntidade : Entidade
{
    protected Filtro()
    {
        Pagina = 1;
        TamanhoPagina = 15;
    }
    
    public int? Id { get; set; }
    
    public string? Busca { get; set; } = null!;
    
    public int Pagina { get; set; }
    
    public int TamanhoPagina { get; set; }
    
    public string OrdemPor { get; set; } = null!;
    
    public string Ordem { get; set; } = null!;

    public bool? Ativo { get; set; }

    public bool? Todos { get; set; }
    
    public abstract Expression<Func<TEntidade, object>> Propriedades();

    public void PrepararPaginacao()
    {
        TamanhoPagina = TamanhoPagina <= 0 ? 10 : TamanhoPagina;
        Pagina = Pagina <= 0 ? 0 : (Pagina - 1) * TamanhoPagina;
    }

    public abstract Expression<Func<TEntidade, bool>> Consulta();

    public virtual string Ordenacao() => $"{OrdemPor} {Ordem}";    
}