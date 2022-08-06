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

    public dynamic Get()
    {
        return _context.Produtos
            .Include(p => p.Categoria)
            .Where(p => p.Ativo)
            .Select(p => new
            {
                p.Nome,
                p.Preco,
                Categoria = p.Categoria.Nome,
                Imagens = p.Imagens.Select(i => new
                {
                    i.Id,
                    i.Nome,
                    i.NomeArquivo,
                    i.Principal
                })

            })
            .OrderBy(x => x.Nome)
            .ToList();
    }
    public dynamic Search(string text, int pagina)
    {
        var produtos = _context.Produtos
            .Include(p => p.Categoria)
            .Where(p => p.Ativo && (p.Nome.ToUpper().Contains(text.ToUpper()) || p.Descricao.ToUpper().Contains(text.ToUpper())))
            .Skip(TamanhoPagina * (pagina - 1))
            .Take(TamanhoPagina)
            .Select(p => new
            {
                p.Nome,
                p.Preco,
                Categoria = p.Categoria.Nome,
                Imagens = p.Imagens.Select(i => new
                {
                    i.Id,
                    i.Nome,
                    i.NomeArquivo,
                    i.Principal
                })

            })
            .OrderBy(x => x.Nome)
            .ToList();

        var ProductsCount = _context.Produtos
            .Where(x => x.Ativo && (x.Nome.ToUpper().Contains(text.ToUpper()) || x.Descricao.ToUpper().Contains(text.ToUpper())))
            .Count();

        var PageCount = (ProductsCount / TamanhoPagina);

        if (PageCount < 1)
        {
            PageCount = 1;
        }

        return new { produtos, PageCount };
    }

    public dynamic Detail(int id)
    {
        return _context.Produtos
            .Include(p => p.Imagens)
            .Include(p => p.Categoria)
            .Where(p => p.Ativo && p.Id == id)
            .Select(p => new
            {
                p.Id,
                p.Nome,
                p.Codigo,
                p.Descricao,
                p.Preco,
                Categoria = new
                {
                    p.Categoria.Id,
                    p.Categoria.Nome
                },
                Imagens = p.Imagens.Select(i => new
                {
                    i.Id,
                    i.Nome,
                    i.NomeArquivo,
                    i.Principal
                })
            })
            .OrderBy(p => p.Nome)
            .FirstOrDefault()!;
    }

    public dynamic Imagens(int id)
    {
        return _context.Produtos
            .Include(p => p.Imagens)
            .Where(p => p.Ativo && p.Id == id)
            .SelectMany(p => p.Imagens, (produto, imagem) => new
            {
                IdProduto = produto.Id,
                imagem.Id,
                imagem.Nome,
                imagem.NomeArquivo,
                imagem.Principal
            })

            .OrderBy(p => p.Nome)
            .FirstOrDefault()!;
    }

}
