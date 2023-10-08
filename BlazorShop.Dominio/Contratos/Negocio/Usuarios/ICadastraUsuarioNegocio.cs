using BlazorShop.Dominio.Entidades;
using Flunt.Notifications;

namespace BlazorShop.Dominio.Contratos.Negocio.Usuarios;

public interface ICadastraUsuarioNegocio
{
    Task<IReadOnlyCollection<Notification>> Cadastrar(Usuario usuario);
}