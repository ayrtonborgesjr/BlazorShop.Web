using BlazorShop.Aplicacao.Modelos.Usuarios;
using BlazorShop.Dominio.Entidades;
using Mapster;

namespace BlazorShop.Configuracao.Configuracao;

public static class Mapeamentos
{
    public static void Registrar()
    {
        DominioAplicacao();
        AplicacaoDominio();
    }

    private static void DominioAplicacao()
    {
        TypeAdapterConfig<Usuario, UsuarioModelo>.NewConfig();
    }

    private static void AplicacaoDominio()
    {
        TypeAdapterConfig<UsuarioModelo, Usuario>.NewConfig();
    }
}