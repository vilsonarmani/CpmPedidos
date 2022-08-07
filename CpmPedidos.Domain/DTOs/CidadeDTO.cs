namespace CpmPedidos.Domain;

public class CidadeDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Uf { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public bool Ativo { get; set; }
}
