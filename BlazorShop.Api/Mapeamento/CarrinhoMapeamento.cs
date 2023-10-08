using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Api.Mapeamento;

internal sealed class CarrinhoMapeamento : MapeamentoBase<Carrinho>
{
    protected override void Mapear(EntityTypeBuilder<Carrinho> builder)
    {
        builder.ToTable("Carrinhos");
        
        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);
    }
}