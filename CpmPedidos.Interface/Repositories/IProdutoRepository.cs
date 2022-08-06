using CpmPedidos.Domain;

namespace CpmPedidos.Interface;

public interface IProdutoRepository
{
    List<Produto> Get();
    List<Produto> Search(string text, int pagina);
    Produto Detail(int id);


}
