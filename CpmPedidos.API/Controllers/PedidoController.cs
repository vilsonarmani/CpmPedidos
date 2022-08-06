using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : AppBaseController
{
    
    public PedidoController(IServiceProvider serviceProvider) : base(serviceProvider){}


}
