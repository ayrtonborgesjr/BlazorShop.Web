using BlazorShop.Aplicacao.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;

public class BaseController : Controller
{
    protected void AdicionarErros(IEnumerable<string> erros)
    {
        foreach (var error in erros)
            ModelState.AddModelError("", error);
    }

    protected void AdicionarErros(Resultado resultado)
    {
        foreach (var erro in resultado.Erros)
            ModelState.AddModelError("Geral", erro);
    }

    protected void MostraSucesso(string mensagem = "Cadastro realizado com sucesso") =>
        TempData["Sucesso"] = mensagem;

}