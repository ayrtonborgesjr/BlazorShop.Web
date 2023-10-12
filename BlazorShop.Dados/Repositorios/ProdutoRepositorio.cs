using BlazorShop.Dados.Contexto;
using BlazorShop.Dominio.Contratos.Repositorios;
using BlazorShop.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Dados.Repositorios;

public sealed class ProdutoRepositorio : Repositorio<Produto>, IProdutoRepositorio
{
    public ProdutoRepositorio(AppDbContexto contexto) : base(contexto)
    {
    }

    public async Task Inserir(Produto produto)
    {
        Consulta.Add(produto);
        await Contexto.SaveChangesAsync();
    }

    public async Task Atualizar(Produto produto)
    {
        Consulta.Update(produto);
        await Contexto.SaveChangesAsync();
    }

    public async Task Excluir(Produto produto)
    {
        Consulta.Remove(produto);
        await Contexto.SaveChangesAsync();
    }

    public async Task<Produto?> BuscarProduto(Guid chave) =>
        await Consulta
            .Include(x => x.Categoria)
            .Where(a => a.Chave == chave)
            .FirstOrDefaultAsync();

    public async Task<Produto?> BuscarProduto(int id) =>
        await Consulta
            .Include(x => x.Categoria)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<Produto>> BuscarItensPorCategoria(int id) =>
        await Consulta
            .Include(x => x.Categoria)
            .Where(x => x.CategoriaId == id).ToListAsync();

    public async Task<IEnumerable<Produto>> ListarProdutosDetalhado() => 
        await Consulta
            .Include(x => x.Categoria).ToListAsync();
}