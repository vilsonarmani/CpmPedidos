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
    public dynamic Get([FromQuery] string ordem = "")
    {
        ///get the service provider instance
        var rep = getProdutoRepository();
        return rep.Get(ordem);
    }

    [HttpGet]
    [Route("search/{text}/{pagina?}")]
    public dynamic GetSearch(string text, int pagina = 1, [FromQuery] string order = "ASC")
    {      
        return getProdutoRepository()
            .Search(text, pagina, order);
    }

    [HttpGet]
    [Route("{id}")]
    public dynamic Detail(int? id)
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
    
    [HttpGet]
    [Route("{id}/imagens")]
    public dynamic Imagens(int? id)
    {
        if ((id ?? 0) > 0)
        {
            return getProdutoRepository()
                .Imagens(id!.Value);
        }
        else
        {
            return null!;
        }

    }


}
