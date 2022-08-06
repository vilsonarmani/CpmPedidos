using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository;

public class ProdutoRepository : BaseRepository, IProdutoRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public List<Produto> Get()
    {
        return _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.Ativo)
            .OrderBy(x => x.Nome)
            .ToList();        
    }
    public List<Produto> Search(string text, int pagina)
    {
        return _context.Produtos
            .Include(x => x.Categoria)
            .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
            .Skip(TamanhoPagina * (pagina - 1))
            .Take(TamanhoPagina)
            .OrderBy(x => x.Nome)
            .ToList()
            ;
    }
    
    public Produto Detail(int id)
    {
        return _context.Produtos
            .Include(x => x.Imagens)
            .Include(x => x.Categoria)
            .Where(x => x.Ativo && x.Id == id)
            .OrderBy(x => x.Nome)
            .FirstOrDefault()!;
    }

}
