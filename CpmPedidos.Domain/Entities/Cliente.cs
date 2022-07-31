using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain;

public class Cliente : BaseDomain, IExibivel
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int IdEndereco { get; set; }
    public virtual Endereco Endereco { get; set; }
    public bool Ativo { get; set; }

    public virtual List<Pedido> Pedidos { get; set;}
}
