using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers;
[ApiController]
[Route("[controller]")]
public class PedidoController : AppBaseController
{    
    public PedidoController(IServiceProvider serviceProvider) : base(serviceProvider){}

    /// <summary>
    /// Return the today maximum Ticket
    /// </summary>
    /// <returns>Return the today maximum Ticket</returns>    
    [HttpGet]
    [Route("ticket-maximo")]
    public decimal TicketMaximo()
    {
        return GetService<IPedidoRepository>().TicketMaximo();
    }

    [HttpGet, Route("por-cliente", Name = "PedidosClientes")]
    /// URI E.g: (manual tests)
    /// Pedido/por-cliente?dateStart=2021-01-01T00:00:00&dateEnd=2022-08-06T23:59:59
    /// Pedido/por-cliente?dateStart=2022-08-06T23:59:59&dateEnd=2021-01-01T00:00:00
    /// Pedido/por-cliente
    public dynamic PedidosClientes([FromQuery]DateTime dateStart, DateTime dateEnd)
    {
        return GetService<IPedidoRepository>().PedidosClientes(dateStart, dateEnd);
    }

    [HttpPost, Route("")]
    public string SalvarPedido(PedidoDTO pedido)
    {
        return GetService<IPedidoRepository>().SalvarPedido(pedido);
    }
}
