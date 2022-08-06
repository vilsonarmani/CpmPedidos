using CpmPedidos.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Repository;

public class PedidoRepository : BaseRepository, IPedidoRepository
{
   

    public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext) {}

    public decimal TicketMaximo()
    {
        var today = DateTime.Today;
        return _context.Pedidos
            .Where(x => x.CriadoEm.Date == today)
            .Max(x => (decimal?)x.ValorTotal) ?? 0;

    }

    public dynamic PedidosClientes()
    {
        DateTime today = DateTime.Today;

        DateTime inicioMes = new DateTime(today.Year, today.Month, 1);
        DateTime finalMes = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));


        return _context.Pedidos
            .Where(p => p.CriadoEm.Date >= inicioMes && p.CriadoEm.Date <= finalMes)
            .GroupBy(pedido => new { pedido.IdCliente, pedido.Cliente.Nome })
            .Select(x => new
            {
                Cliente = x.Key.Nome,
                Pedidos = x.Count(),
                Total = x.Sum(p => p.ValorTotal)
            })
            .ToList();
    }
}
