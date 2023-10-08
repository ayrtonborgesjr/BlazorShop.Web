using BlazorShop.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Api.Mapeamento;

internal sealed class CarrinhoItemMapeamento : MapeamentoBase<CarrinhoItem>
{
    protected override void Mapear(EntityTypeBuilder<CarrinhoItem> builder)
    {
        builder.ToTable("CarrinhoItens");
        
        builder.Property(x => x.Quantidade).IsRequired();
        
        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);
    }
}