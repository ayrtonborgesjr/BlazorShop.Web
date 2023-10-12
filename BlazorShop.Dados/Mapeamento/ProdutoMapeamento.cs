using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Dados.Mapeamento;

internal sealed class ProdutoMapeamento : MapeamentoBase<Produto>
{
    protected override void Mapear(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
        builder.Property(x => x.Descricao).HasColumnType("varchar(200)").IsRequired();
        builder.Property(x => x.ImagemUrl).HasColumnType("varchar(200)").IsRequired();
        builder.Property(x => x.Preco).HasColumnType("decimal(10, 2)").IsRequired();
        builder.Property(x => x.Quantidade).IsRequired();
        
        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);
    }  
}