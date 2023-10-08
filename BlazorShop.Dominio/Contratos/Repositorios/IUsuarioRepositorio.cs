using BlazorShop.Dominio.Entidades;

namespace BlazorShop.Dominio.Contratos.Repositorios;

public interface IUsuarioRepositorio : IRepositorio<Usuario>
{
    Task<dynamic> Buscar(Filtro<Usuario> filtro);
    Task Inserir(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task Excluir(Usuario usuario);
    Task<Usuario?> BuscarUsuario(Guid chave);
}