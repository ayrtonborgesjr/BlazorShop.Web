using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Dominio.DTOs;

public class CarrinhoItemAtualizaQuantidadeDto
{
    public int CarrinhoItemId { get; set; }
    public int Quantidade { get; set; }
}