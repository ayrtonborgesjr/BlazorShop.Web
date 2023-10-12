using BlazorShop.Dados.Mapeamento;
using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Dados.Contexto;

public class AppDbContexto : DbContext
{
    public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options)
    {
    }

    public DbSet<Carrinho>? Carrinhos { get; set; }
    public DbSet<CarrinhoItem>? CarrinhoItens { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Usuario>? Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoriaMapeamento());
        modelBuilder.ApplyConfiguration(new ProdutoMapeamento());
        modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
        modelBuilder.ApplyConfiguration(new CarrinhoMapeamento());
        modelBuilder.ApplyConfiguration(new CarrinhoItemMapeamento());
    }
}