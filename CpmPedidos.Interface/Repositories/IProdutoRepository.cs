using CpmPedidos.Domain;

namespace CpmPedidos.Interface;

public interface IProdutoRepository
{
    dynamic Get();
    dynamic Search(string text, int pagina);
    dynamic Detail(int id);
    dynamic Imagens(int id);
}
