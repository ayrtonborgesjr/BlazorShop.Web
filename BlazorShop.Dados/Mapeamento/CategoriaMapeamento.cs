using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Dados.Mapeamento;

internal sealed class CategoriaMapeamento : MapeamentoBase<Categoria>
{
    protected override void Mapear(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");

        builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
        builder.Property(x => x.IconCss).HasColumnType("varchar(50)").IsRequired();
        
        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);
    }
}