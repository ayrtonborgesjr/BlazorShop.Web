using BlazorShop.Dados.Contexto;
using BlazorShop.Dados.Repositorios;
using BlazorShop.Aplicacao.Contratos;
using BlazorShop.Aplicacao.Servicos.Produtos;
using BlazorShop.Aplicacao.Servicos.Usuarios;
using BlazorShop.Dominio.Contratos.Negocio.Usuarios;
using BlazorShop.Dominio.Contratos.Repositorios;
using BlazorShop.Dominio.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorShop.Configuracao.Configuracao;

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
        servicos.AddScoped<IBuscaProdutoServico, BuscaProdutoServico>();

        // Negócio
        servicos.AddScoped<ICadastraUsuarioNegocio, CadastraUsuarioNegocio>();

        // Repositório
        servicos.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        servicos.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
    }
}