using CpmPedidos.Domain;

namespace CpmPedidos.Interface;

public interface IProdutoRepository
{
    List<Produto> Get();
    dynamic Search(string text, int pagina);
    Produto Detail(int id);


}
