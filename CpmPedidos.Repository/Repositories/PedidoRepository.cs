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
}
