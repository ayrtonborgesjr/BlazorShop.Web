using BlazorShop.Aplicacao.Contratos;
using BlazorShop.Aplicacao.Filtros;
using BlazorShop.Aplicacao.Modelos.Usuarios;
using BlazorShop.Dominio.Contratos.Repositorios;
using Mapster;

namespace BlazorShop.Aplicacao.Servicos.Usuarios;

public sealed class BuscaUsuarioServico : IBuscaUsuarioServico
{
    private readonly IUsuarioRepositorio _repositorio;

    public BuscaUsuarioServico(IUsuarioRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<dynamic> Buscar(UsuarioFiltro filtro) => 
        await _repositorio.Buscar(filtro);

    public async Task<UsuarioModelo?> Buscar(Guid? chave) =>
        (await _repositorio.Buscar(chave.GetValueOrDefault()))?.Adapt<UsuarioModelo>();
}