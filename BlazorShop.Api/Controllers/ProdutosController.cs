using BlazorShop.Aplicacao.Contratos;
using BlazorShop.Dominio.Contratos.Repositorios;
using BlazorShop.Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : BaseController
{
    private readonly IBuscaProdutoServico _buscaProdutoServico;

    public ProdutosController(IBuscaProdutoServico produtoServico)
    {
        _buscaProdutoServico = produtoServico;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> ListarProdutosDetalhado()
    {
        try
        {
            var produtos = await _buscaProdutoServico.ListarProdutosDetalhado();
            return Ok(produtos);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }
    }
    
    [HttpGet("{chave:guid}")]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> BuscarItensPorCategoria(Guid chave)
    {
        try
        {
            var produto = await _buscaProdutoServico.BuscarDetalhado(chave);
            if (produto is null)
            {
                return BadRequest("Não foi possível localizar o produto");
            }
            else
            {
                return Ok(produto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> BuscarItensPorCategoria(int id)
    {
        try
        {
            var produto = await _buscaProdutoServico.BuscarDetalhado(id);
            if (produto is null)
            {
                return BadRequest("Não foi possível localizar o produto");
            }
            else
            {
                return Ok(produto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar a base de dados");
        }
    }
}