using Flunt.Notifications;

namespace BlazorShop.Dominio.Entidades;

public abstract class Entidade : Notifiable<Notification>
{
    protected Entidade() { }
    
    protected Entidade(int id) => Id = id;
    protected Entidade(Guid chave) => Chave = chave;
    protected Entidade(int id, Guid chave)
    {
        Id = id;
        Chave = chave;
    }

    public int Id { get; private protected set; }
    public Guid Chave { get; private set; }
}