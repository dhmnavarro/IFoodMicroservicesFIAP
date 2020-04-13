using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using MicroServices.Model;
using MicroServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusPedidoController : ControllerBase
    {
        private readonly IStatusPedidoRepository _statusRepository;

        public StatusPedidoController(IStatusPedidoRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var status = _statusRepository.SelecionaStatusPedidos();
            return new OkObjectResult(status);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var status = _statusRepository.SelecionaStatusPedidoByID(id);
            return new OkObjectResult(status);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StatusPedido model)
        {
            using (var scope = new TransactionScope())
            {
                _statusRepository.InsereStatusPedido(model);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] StatusPedido model)
        {
            if (model != null)
            {
                using (var scope = new TransactionScope())
                {
                    _statusRepository.AtualizaStatusPedido(model);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _statusRepository.ApagaStatusPedido(id);
            return new OkResult();
        }
    }
}
