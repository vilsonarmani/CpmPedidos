using CpmPedidos.Domain;
using CpmPedidos.Interface;

namespace CpmPedidos.Repository;

public class CidadeRepository : BaseRepository, ICidadeRepository
{
    private bool NomeJaExisteNaBBase(CidadeDTO model)
    {
        return _context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper());
    }
    public CidadeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public dynamic Get()
    {
        return _context.Cidades
            .Where(c => c.Ativo)
            .Select(cidade => new
            {
                cidade.Id,
                cidade.Nome,
                cidade.Uf,
                cidade.Ativo
            })
            .ToList();
    }

    public int Criar(CidadeDTO model)
    {
        if (model.Id > 0)
            return 0;

        if (_context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper()))
            return 0;

        var entity = new Cidade
        {
            Nome = model.Nome,
            Uf = model.Uf,
            Ativo = model.Ativo
        };

        try
        {
            _context.Cidades.Add(entity);
            _context.SaveChanges();

            return entity.Id;

        }
        catch (Exception ex)
        {
            ///sendMessage Add Flunt
            /// Log e Flunt (TODO: Add Packages and use {Technical Debt})
        }

        return -1; /// TODO: Set Constant {Technical Debt}

    }

    public int Alterar(CidadeDTO model)
    {
        if (model.Id >= 0)
            return -1;/// TODO: Set Constant {Technical Debt}

        var entity = _context.Cidades.Find(model.Id);

        if (entity == null)
            return -1;/// TODO: Set Constant {Technical Debt}

        if (_context.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == model.Nome.ToUpper() && x.Id != model.Id))
            return -1;/// TODO: Set Constant {Technical Debt}

        entity.Nome = model.Nome;
        entity.Uf = model.Uf;
        entity.Ativo = model.Ativo;

        try
        {
            _context.Cidades.Update(entity);
            _context.SaveChanges();

            return entity.Id;
        }
        catch (Exception ex)
        {
            /// Log e Flunt (TODO: Add Packages and use {Technical Debt})
        }

        return -1; /// TODO: Set Constant {Technical Debt}


    }

    public bool Excluir(int id)
    {
        if (id <= 0)
        {
            return false;
        }

        var entity = _context.Cidades.Find(id);

        if (entity == null)
            return false;

        try
        {
            _context.Cidades.Remove(entity);
            _context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            /// Log e Flunt (TODO: Add Packages and use {Technical Debt})
        }

        return true;/// TODO: Set Constant {Technical Debt}
    }
}
