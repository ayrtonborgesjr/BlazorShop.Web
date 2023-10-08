using BlazorShop.Api.Contexto;
using BlazorShop.Api.Repositorios;
using BlazorShop.Aplicacao.Contratos;
using BlazorShop.Aplicacao.Servicos.Usuarios;
using BlazorShop.Dominio.Contratos.Negocio.Usuarios;
using BlazorShop.Dominio.Contratos.Repositorios;
using BlazorShop.Dominio.Negocio;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Api.Configuracao;

public static class Dependencias
{
    public static void Adm(IServiceCollection servicos, IConfiguration configuracao)
    {
        Contextos(servicos, configuracao);
        Servicos(servicos);
    }

    private static void Contextos(IServiceCollection servicos, IConfiguration configuracao) =>
        servicos.AddDbContextPool<AppDbContexto>(_ =>
            _.UseSqlServer(configuracao.GetConnectionString("DefaultConnection")));
    private static void Servicos(IServiceCollection servicos)
    {
        // Serviços
        servicos.AddScoped<IBuscaUsuarioServico, BuscaUsuarioServico>();

        // Negócio
        servicos.AddScoped<ICadastraUsuarioNegocio, CadastraUsuarioNegocio>();

        // Repositorio
        servicos.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
    }
}