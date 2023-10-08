using Flunt.Notifications;

namespace BlazorShop.Aplicacao.Modelos;

public sealed class Resultado
{
    private readonly List<string> _erros;

    public string MensagemSucesso { get; }
    public Resultado() => _erros = new List<string>();

    public Resultado(string mensagemSucesso)
    {
        MensagemSucesso = mensagemSucesso;
        _erros = new List<string>();
    }
    
    public Resultado(IEnumerable<Notification> erros) =>
        _erros = new List<string>(erros.Select(x => x.Message));

    public IReadOnlyCollection<string> Erros => _erros.AsReadOnly();

    public bool Sucesso => !_erros.Any();
}


