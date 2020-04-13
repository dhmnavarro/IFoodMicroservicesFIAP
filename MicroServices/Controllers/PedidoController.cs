using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using MicroServices.Database;
using MicroServices.Model;
using MicroServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = _pedidoRepository.SelecionaPedidos();
            return new OkObjectResult(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pedido = _pedidoRepository.SelecionaPedidoByID(id);
            return new OkObjectResult(pedido);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido model)
        {
            using (var scope = new TransactionScope())
            {
                _pedidoRepository.InserePedido(model);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = model.CodigoPedido }, model);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Pedido model)
        {
            if (model != null)
            {
                using (var scope = new TransactionScope())
                {
                    _pedidoRepository.AtualizaPedido(model);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pedidoRepository.ApagaPedido(id);
            return new OkResult();
        }
    }
}
