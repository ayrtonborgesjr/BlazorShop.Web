using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BlazorShop.Api.Mapeamento;

internal abstract class MapeamentoBase<TEntidade> : IEntityTypeConfiguration<TEntidade> where TEntidade : Entidade
{
    public void Configure(EntityTypeBuilder<TEntidade> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(e => e.Chave).HasValueGenerator<GuidValueGenerator>().IsRequired();
        
        builder.HasIndex(a => a.Chave);
        
        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);

        Mapear(builder);
    }
    
    protected abstract void Mapear(EntityTypeBuilder<TEntidade> builder);
}