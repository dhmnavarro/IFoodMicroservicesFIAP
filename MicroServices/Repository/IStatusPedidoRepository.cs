using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Model;

namespace MicroServices.Repository
{
    public interface IStatusPedidoRepository
    {
        IEnumerable<StatusPedido> SelecionaStatusPedidos();
        StatusPedido SelecionaStatusPedidoByID(int codStatus);
        void InsereStatusPedido(StatusPedido status);
        void ApagaStatusPedido(int codPedido);
        void AtualizaStatusPedido(StatusPedido status);
        void Save();
    }
}
