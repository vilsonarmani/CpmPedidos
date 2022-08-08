namespace CpmPedidos.Domain;

public class PedidoDTO
{
    public int IdCliente { get; set; }

    public virtual List<ProdutoPedidoDTO> Produtos { get; set; }
}
