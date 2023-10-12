namespace BlazorShop.Dominio.DTOs;

public class CategoriaDto
{
    public int Id { get; set; }
    public Guid Chave { get; set; }
    public string? Nome { get; set; }
    public string? IconCss { get; set; }
}