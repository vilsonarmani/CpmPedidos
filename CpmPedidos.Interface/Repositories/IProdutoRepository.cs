using CpmPedidos.Domain;

namespace CpmPedidos.Interface;

public interface IProdutoRepository
{
    List<Produto> Get();
    List<Produto> Search(string text);
    Produto Detail(int id);


}
