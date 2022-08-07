using CpmPedidos.Interface;
using CpmPedidos.Domain;
using Microsoft.AspNetCore.Mvc;


namespace CpmPedidos.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CidadeController : AppBaseController
{    
    public CidadeController(IServiceProvider serviceProvider) : base(serviceProvider){}
   

    /// <summary>
    /// Return the today maximum Ticket
    /// </summary>
    /// <returns>Return the today maximum Ticket</returns>    
    [HttpGet]
    public dynamic Get()
    {
        return GetService<ICidadeRepository>().Get();
    }

    [HttpPost]
    public int Criar(CidadeDTO model)
    {
        return GetService<ICidadeRepository>().Criar(model);        
    }
    
    [HttpPut]
    public int Alterar(CidadeDTO model)
    {
        return GetService<ICidadeRepository>().Alterar(model);        
    }


}
