using CpmPedidos.Domain;

namespace CpmPedidos.Interface;

public interface IProdutoRepository
{
    dynamic Get(string ordem);
    dynamic Search(string text, int pagina, string order);
    dynamic Detail(int id);
    dynamic Imagens(int id);
}
