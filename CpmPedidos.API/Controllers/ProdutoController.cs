using CpmPedidos.Interface;
using CpmPedidos.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : AppBaseController
{
    private IProdutoRepository getProdutoRepository()
    {        
        return (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository))!; 
    }
    public ProdutoController(IServiceProvider serviceProvider): base(serviceProvider)
    {
    }

    [HttpGet]
    public IEnumerable<Produto> Get()
    {
        ///get the service provider instance
        var rep = getProdutoRepository();
        return rep.Get();
    }

    [HttpGet]
    [Route("search/{text}")]
    public IEnumerable<Produto> GetSearch(string text)
    {      
        return getProdutoRepository()
            .Search(text);
    }

    [HttpGet]
    [Route("{id}")]
    public Produto Detail(int? id)
    {
        if ((id ?? 0) > 0)
        {
            return getProdutoRepository()
                .Detail(id!.Value);
        }
        else
        {
            return null!;
        }

    }


}
