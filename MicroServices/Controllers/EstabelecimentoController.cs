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
    public class EstabelecimentoController : ControllerBase
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoController(IEstabelecimentoRepository estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var estabelecimentos = _estabelecimentoRepository.SelecionaEstabelecimentos();
            return new OkObjectResult(estabelecimentos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var estabelecimento = _estabelecimentoRepository.SelecionaEstabelecimentoByID(id);
            return new OkObjectResult(estabelecimento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Estabelecimento model)
        {
            using (var scope = new TransactionScope())
            {
                _estabelecimentoRepository.InsereEstabelecimento(model);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = model.CodigoEstabelecimento }, model);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Estabelecimento model)
        {
            if (model != null)
            {
                using (var scope = new TransactionScope())
                {
                    _estabelecimentoRepository.AtualizaEstabelecimento(model);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _estabelecimentoRepository.ApagaEstabelecimento(id);
            return new OkResult();
        }
    }
}
