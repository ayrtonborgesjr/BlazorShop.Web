using BlazorShop.Dominio.Contratos.Negocio.Usuarios;
using BlazorShop.Dominio.Contratos.Repositorios;
using BlazorShop.Dominio.Entidades;
using Flunt.Notifications;

namespace BlazorShop.Dominio.Negocio;

public class CadastraUsuarioNegocio : ICadastraUsuarioNegocio
{
    private readonly IUsuarioRepositorio _repositorio;

    public CadastraUsuarioNegocio(IUsuarioRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<IReadOnlyCollection<Notification>> Cadastrar(Usuario usuario)
    {
        if (!usuario.IsValid)
            return usuario.Notifications;
        
        if (await _repositorio.Existe(x => x.Nome.Trim().ToLower().Equals(usuario.Nome.Trim().ToLower())))
        {
            return new[] { new Notification("", "Já existe um usuário com o mesmo nome cadastrado") };
        }

        await _repositorio.Inserir(usuario);
            
        return new List<Notification>();
    }
}