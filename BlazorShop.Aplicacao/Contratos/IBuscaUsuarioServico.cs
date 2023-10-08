using BlazorShop.Aplicacao.Filtros;
using BlazorShop.Aplicacao.Modelos.Usuarios;

namespace BlazorShop.Aplicacao.Contratos;

public interface IBuscaUsuarioServico
{
    Task<dynamic> Buscar(UsuarioFiltro filtro);
    Task<UsuarioModelo?> Buscar(Guid? chave);
}