using BlazorShop.Dominio.Entidades;
using System.Linq.Expressions;

namespace BlazorShop.Dominio.Contratos;

public interface IRepositorio<TEntidade> where TEntidade : Entidade
{
    Task<TEntidade?> Buscar(int id);
    Task<TEntidade?> Buscar(Guid chave);
    Task<TEntidade?> Buscar(Expression<Func<TEntidade, bool>> expressao);
    Task<dynamic> Buscar(Filtro<TEntidade> paginacao);
    Task<bool> Existe(Expression<Func<TEntidade, bool>> expressao);

}