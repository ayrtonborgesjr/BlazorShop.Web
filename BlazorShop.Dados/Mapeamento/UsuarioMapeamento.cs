using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Dados.Mapeamento;

internal sealed class UsuarioMapeamento : MapeamentoBase<Usuario>
{
    protected override void Mapear(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        
        builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();
        
        builder.Ignore(x => x.IsValid);
        builder.Ignore(x => x.Notifications);
    }
}