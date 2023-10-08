using BlazorShop.Aplicacao.Contratos;
using BlazorShop.Aplicacao.Filtros;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : BaseController
{
    private readonly IBuscaUsuarioServico _buscaUsuarioServico;

    public UsuarioController(IBuscaUsuarioServico buscaUsuarioServico)
    {
        _buscaUsuarioServico = buscaUsuarioServico;
    }

    [HttpGet]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Buscar([FromQuery] UsuarioFiltro filtro) =>
        Ok(await _buscaUsuarioServico.Buscar(filtro));
}