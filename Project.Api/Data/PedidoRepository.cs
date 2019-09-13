using Project.Api.Models;

namespace Project.Api.Data
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DataContext context) : base(context)
        {
        }
    }
}