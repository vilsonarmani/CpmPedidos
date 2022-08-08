using CpmPedidos.Domain;

namespace CpmPedidos.Interface;

public interface IPedidoRepository
{
    decimal TicketMaximo();
    dynamic PedidosClientes(DateTime dateStart, DateTime dateEnd);

    string SalvarPedido(PedidoDTO pedido);
}
