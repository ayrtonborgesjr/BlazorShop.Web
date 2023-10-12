using BlazorShop.Dados.Contexto;
using BlazorShop.Dominio.Contratos;
using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using LinqKit;
using BlazorShop.Dominio;

namespace BlazorShop.Dados.Repositorios;

public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade
{
    protected Repositorio(AppDbContexto contexto)
    {
        Contexto = contexto;

        Consulta = Contexto.Set<TEntidade>();
        Lista = Consulta.AsNoTracking().AsQueryable();
    }
    
    protected AppDbContexto Contexto { get; }
    protected DbSet<TEntidade> Consulta { get; }
    public IQueryable<TEntidade> Lista { get; }
    
    public virtual async Task<TEntidade?> Buscar(int id) =>
        await Consulta.FindAsync(id);

    public virtual async Task<TEntidade?> Buscar(Guid chave) =>
        await Consulta.Where(a => a.Chave == chave).FirstOrDefaultAsync();

    public virtual async Task<TEntidade?> Buscar(Expression<Func<TEntidade, bool>> expressao) =>
        await Consulta.Where(expressao).FirstOrDefaultAsync();

    public virtual async Task<dynamic> Buscar(Filtro<TEntidade> paginacao)
    {
        paginacao.PrepararPaginacao();
        var filtro = paginacao.Consulta();
        var consulta = Consulta.AsExpandable().Where(filtro).AsNoTracking();
        var total = await consulta.CountAsync();
        consulta = !paginacao.Todos.GetValueOrDefault(false)
            ? consulta
                .OrderBy(paginacao.Ordenacao())
                .Skip(paginacao.Pagina)
                .Take(paginacao.TamanhoPagina)
            : consulta.OrderBy(paginacao.Ordenacao());
        var resultado = await consulta
            .Select(paginacao.Propriedades())
            .ToListAsync();

        return new { Lista = resultado, Total = total };
    }

    public Task<bool> Existe(Expression<Func<TEntidade, bool>> expressao) => Consulta.AnyAsync(expressao);
}