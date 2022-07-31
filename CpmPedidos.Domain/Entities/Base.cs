namespace CpmPedidos.Domain;

public class Endereco: BaseDomain
{
    public TipoEnum Tipo { get; set; }
    public string Logradouro { get; set; }
    public string Bairro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Cep { get; set; }

    public int IdCidade { get; set; } //specify the foreign Key
    public virtual Cidade Cidade { get; set; } ///virtual to do the lazyLoad


}
