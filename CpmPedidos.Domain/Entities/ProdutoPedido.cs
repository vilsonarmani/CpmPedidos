using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain;

public class ProdutoPedido : BaseDomain
{

    public int Quantidade { get; set; }
    public decimal Preco { get; set; }

    public int IdProduto { get; set; }
    public virtual Produto Produto { get; set; }

    /// <summary>
    /// Pedido Association
    /// </summary>
    public int IdPedido { get; set; }
    public virtual Pedido Pedido { get; set; }

}
