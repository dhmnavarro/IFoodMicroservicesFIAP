using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Model;

namespace MicroServices.Repository
{
    public interface IPedidoRepository
    {
        IEnumerable<Pedido> SelecionaPedidos();
        Pedido SelecionaPedidoByID(int codPedido);
        void InserePedido(Pedido pedido);
        void ApagaPedido(int codPedido);
        void AtualizaPedido(Pedido pedido);
        void Save();
    }
}
