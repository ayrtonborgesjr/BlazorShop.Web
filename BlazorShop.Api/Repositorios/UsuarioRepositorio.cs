using BlazorShop.Api.Contexto;
using BlazorShop.Dominio.Contratos.Repositorios;
using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Repositorios;

public sealed class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
{
    public UsuarioRepositorio(AppDbContexto contexto) : base(contexto)
    {
    }
    
    public async Task Inserir(Usuario usuario)
    {
        Consulta.Add(usuario);
        await Contexto.SaveChangesAsync();
    }
    
    public async Task Atualizar(Usuario usuario)
    {
        Consulta.Update(usuario);
        await Contexto.SaveChangesAsync();
    }

    public async Task Excluir(Usuario usuario)
    {
        Consulta.Remove(usuario);
        await Contexto.SaveChangesAsync();
    }

    public async Task<Usuario?> BuscarUsuario(Guid chave) =>
        await Consulta
            .Where(a => a.Chave == chave)
            .FirstOrDefaultAsync();
}