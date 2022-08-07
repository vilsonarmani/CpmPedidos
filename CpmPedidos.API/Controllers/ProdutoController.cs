using CpmPedidos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : AppBaseController
{
    public ProdutoController(IServiceProvider serviceProvider): base(serviceProvider)
    {
    }


    [HttpGet]
    public dynamic Get(string? ordem = "ASC")
    {        
        return GetService<IProdutoRepository>().Get(ordem);
    }

    [HttpGet]
    [Route("search/{text}/{pagina?}")]
    public dynamic GetSearch(string text, int pagina = 1, [FromQuery] string order = "ASC")
    {      
        return GetService<IProdutoRepository>().Search(text, pagina, order);
    }

    [HttpGet]
    [Route("{id}")]
    public dynamic Detail(int? id)
    {
        //Maybe a Extension Method???
        return ((id ?? 0) > 0) ? GetService<IProdutoRepository>().Detail(id!.Value) : null!;
    }
    
    [HttpGet]
    [Route("{id}/imagens")]
    public dynamic Imagens(int? id)
    {
        return  ((id ?? 0) > 0) ? GetService<IProdutoRepository>().Imagens(id!.Value) : null!;
    }
}
