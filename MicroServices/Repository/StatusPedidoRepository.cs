using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Database;
using MicroServices.Model;

namespace MicroServices.Repository
{
    public class StatusPedidoRepository : IStatusPedidoRepository
    {
        private readonly StatusPedidoContext _dbContext;

        public StatusPedidoRepository(StatusPedidoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public IEnumerable<StatusPedido> SelecionaStatusPedidos()
        {
            return _dbContext.StatusPedido.ToList();
        }

        public StatusPedido SelecionaStatusPedidoByID(int codStatus)
        {
            return _dbContext.StatusPedido.Find(codStatus);
        }

        public void InsereStatusPedido(StatusPedido status)
        {
            _dbContext.Add(status);
            Save();
        }

        public void AtualizaStatusPedido(StatusPedido status)
        {
            _dbContext.Entry(status).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }

        public void ApagaStatusPedido(int codStatus)
        {
            var status = _dbContext.StatusPedido.Find(codStatus);
            _dbContext.StatusPedido.Remove(status);
            Save();
        }
    }
}
