using CpmPedidos.Domain;
using CpmPedidos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository;

public class PedidoRepository : BaseRepository, IPedidoRepository
{
    private string GetProximoNumero()
    {
        var ret = 1.ToString("00000");

        var ultimoNumero = _context.Pedidos.Max(x => x.Numero);

        if (!string.IsNullOrEmpty(ultimoNumero))
        {
            ret = (Convert.ToInt32(ultimoNumero) + 1).ToString("00000");
        }

        return ret;
    }

    public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public decimal TicketMaximo()
    {
        var today = DateTime.Today;
        return _context.Pedidos
            .Where(x => x.CriadoEm.Date == today)
            .Max(x => (decimal?)x.ValorTotal) ?? 0;

    }

    public dynamic PedidosClientes(DateTime dateStart, DateTime dateEnd)
    {
        DateTime today = DateTime.Today;

        DateTime inicioMes = new DateTime(today.Year, today.Month, 1);
        DateTime finalMes = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

        if ((DateUtils.DataPura(dateStart) && DateUtils.DataPura(dateEnd)) &&
            (dateEnd > dateStart))
        {
            inicioMes = dateStart;
            finalMes = dateEnd;
        }
        

        return _context.Pedidos
            .Where(p => p.CriadoEm.Date >= inicioMes && p.CriadoEm.Date <= finalMes)
            .GroupBy(
                pedido => new { pedido.IdCliente, pedido.Cliente.Nome },
                (chave, pedidos) => new
                {
                    Cliente = chave.Nome,
                    Pedidos = pedidos.Count(),
                    Total = pedidos.Sum(pedido => pedido.ValorTotal)
                })
            .ToList();
    }

    public string SalvarPedido(PedidoDTO pedido)
    {
        var ret = "";
        try
        {
            var clienteExiste = _context.Clientes
                .Where(c => c.Id == pedido.IdCliente)
                .FirstOrDefault();
            if (clienteExiste == null)
            {
                return "Cliente não localizado ou inexistente";
            }
            var entity = new Pedido
            {
                Numero = GetProximoNumero(),
                IdCliente = pedido.IdCliente,
                CriadoEm = DateTime.Now,
                Produtos = new List<ProdutoPedido>()
            };


            var valorTotal = 0M;

            foreach (var prodPed in pedido.Produtos)
            {
                var precoProduto = _context.Produtos
                    .Where(p => p.Id == prodPed.IdProduto)
                    .Select(p => p.Preco)
                    .FirstOrDefault();
                if (precoProduto > 0)
                {
                    valorTotal += (prodPed.Quantidade * precoProduto);

                    entity.Produtos.Add(new ProdutoPedido
                    {
                        IdProduto = prodPed.IdProduto,
                        Quantidade = prodPed.Quantidade,
                        Preco = precoProduto
                    });
                }

            }

            entity.ValorTotal = valorTotal;

            _context.Pedidos.Add(entity);
            _context.SaveChanges();

            ret = entity.Numero;
        }
        catch (Exception ex)
        {

            throw;
        }

        return ret;
    }
}
