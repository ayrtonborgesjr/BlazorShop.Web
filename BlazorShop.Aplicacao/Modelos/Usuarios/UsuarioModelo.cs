using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Aplicacao.Modelos.Usuarios;

public class UsuarioModelo
{
    public int Id { get; set; }

    public Guid Chave { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
}