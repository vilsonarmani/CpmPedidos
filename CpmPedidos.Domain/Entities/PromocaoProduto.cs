namespace CpmPedidos.Domain;

public class PromocaoProduto: BaseDomain, IExibivel
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    /// <summary>
    /// Imagem
    /// </summary>
    public int IdImagem { get; set; }
    public virtual Imagem Imagem { get; set; }

    /// <summary>
    /// Produto
    /// </summary>
    public int IdProduto { get; set; }
    public virtual Produto Produto { get; set; }

    public bool Ativo { get; set; }
}
