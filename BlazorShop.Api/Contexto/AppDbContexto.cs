using BlazorShop.Api.Mapeamento;
using BlazorShop.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BlazorShop.Api.Contexto;

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
        
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 1, nome: "Maquiagem", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 2, nome: "Cuidados com a Pele", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 3, nome: "Perfumes e Fragrâncias", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 4, nome: "Cuidados com o Corpo", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 5, nome: "Cuidados com as Unhas", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 6, nome: "Cuidados com os Olhos", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 7, nome: "Produtos para o Banho", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 8, nome: "Acessórios de Maquiagem", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 9, nome: "Produtos para Homens", iconCss: "fas fa-spa"));
        // modelBuilder.Entity<Categoria>().HasData(new Categoria(id: 10, nome: "Kits e Conjuntos de Presente", iconCss: "fas fa-spa"));
        //
        // modelBuilder.Entity<Produto>().HasData(new Produto(
        //     id: 1,
        //     nome: "Batom vermelho",
        //     descricao: "Batom cor vermelha",
        //     imagemUrl: "/imagens/maquiagem/batomvermelho.png",
        //     preco: 25.99m,
        //     quantidade: 50,
        //     categoriaId: 1
        // ));
        // modelBuilder.Entity<Produto>().HasData(new Produto(
        //     id: 2,
        //     nome: "Sombra",
        //     descricao: "Sombras para os olhos",
        //     imagemUrl: "/imagens/maquiagem/sombra.png",
        //     preco: 22.45m,
        //     quantidade: 45,
        //     categoriaId: 1
        // ));
        // modelBuilder.Entity<Produto>().HasData(new Produto(
        //     id: 3,
        //     nome: "Limpeza facial",
        //     descricao: "Lenços par limpeza facial - pacote com 25 unidades",
        //     imagemUrl: "/imagens/maquiagem/limpezafacial.png",
        //     preco: 19.90m,
        //     quantidade: 60,
        //     categoriaId: 2
        // ));
        // modelBuilder.Entity<Produto>().HasData(new Produto(
        //     id: 4,
        //     nome: "Protetor Solar - Nivea",
        //     descricao: "Protetor Solar - Nivea - fator 50",
        //     imagemUrl: "/imagens/maquiagem/nivel50.png",
        //     preco: 49.90m,
        //     quantidade: 50,
        //     categoriaId: 2
        // ));
        // modelBuilder.Entity<Produto>().HasData(new Produto(
        //     id: 5,
        //     nome: "Protetor Solar - Isdin",
        //     descricao: "Protetor Solar - Isdin - fator 60",
        //     imagemUrl: "/imagens/maquiagem/isdin60.png",
        //     preco: 59.90m,
        //     quantidade: 40,
        //     categoriaId: 2
        // ));
        //
        // modelBuilder.Entity<Usuario>().HasData(new Usuario( id: 1, nome: "Ayrton"));
        // modelBuilder.Entity<Usuario>().HasData(new Usuario( id: 2, nome: "Priscilla"));
        // modelBuilder.Entity<Usuario>().HasData(new Usuario( id: 3, nome: "Lucas"));
    }
}