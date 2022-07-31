using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Domain;

public class Combo : BaseDomain, IExibivel
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    /// <summary>
    /// Imagem Association
    /// </summary>
    public int IdImagem { get; set; }
    public virtual Imagem Imagem { get; set; }
    
    public List<Produto> Produtos { get; set; }

    public bool Ativo { get; set; }
}
