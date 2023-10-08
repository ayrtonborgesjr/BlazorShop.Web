using Flunt.Notifications;

namespace BlazorShop.Aplicacao.Modelos;

public sealed class Resultado
{
    private readonly ICollection<string> erros;

    public IReadOnlyCollection<string> Erros => erros.ToList();
    public bool Sucesso => !Erros.Any();
    public string MensagemSucesso { get; }

    public Resultado() =>
        erros = new List<string>();

    public Resultado(string mensagemSucesso)
    {
        MensagemSucesso = mensagemSucesso;
        erros = new List<string>();
    }

    public Resultado(IEnumerable<Notification> erros) =>
        this.erros = new List<string>(erros.Select(x => $@"{x.Key} - {x.Message}"));

    public Resultado(IEnumerable<string> erros) =>
        this.erros = erros?.ToList() ?? new List<string>();
}