using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Database;
using MicroServices.Model;

namespace MicroServices.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _dbContext;

        public PedidoRepository(PedidoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<Pedido> SelecionaPedidos()
        {
            return _dbContext.Pedido.ToList();
        }

        public Pedido SelecionaPedidoByID(int codPedido)
        {
            return _dbContext.Pedido.Find(codPedido);
        }

        public void InserePedido(Pedido pedido)
        {
            _dbContext.Add(pedido);
            Save();
        }

        public void AtualizaPedido(Pedido pedido)
        {
            _dbContext.Entry(pedido).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void ApagaPedido(int codPedido)
        {
            var pedido = _dbContext.Pedido.Find(codPedido);
            _dbContext.Pedido.Remove(pedido);
            Save();
        }
    }
}
