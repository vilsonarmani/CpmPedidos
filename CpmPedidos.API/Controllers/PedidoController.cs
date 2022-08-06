using CpmPedidos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers;
[ApiController]
[Route("[controller]")]
public class PedidoController : AppBaseController
{
    
    public PedidoController(IServiceProvider serviceProvider) : base(serviceProvider){}

    private IPedidoRepository getRepository()
    {
        return (IPedidoRepository)_serviceProvider.GetService(typeof(IPedidoRepository))!;
    }

    /// <summary>
    /// Return the today maximum Ticket
    /// </summary>
    /// <returns>Return the today maximum Ticket</returns>    
    [HttpGet]
    [Route("ticket-maximo")]
    public decimal TicketMaximo()
    {
        return getRepository()
            .TicketMaximo();
    }

    [HttpGet]
    [Route("por-cliente")]
    public dynamic PedidosClientes()
    {
        return getRepository().PedidosClientes();
    }


}
