using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ColetaneaDiscos.Models;
using ColetaneaDiscos.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace ColetaneaDiscos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaixaController : ControllerBase
    {
        private readonly IFaixaRepository _faixaRepository;

        public FaixaController(IFaixaRepository faixaRepository)
        {
            _faixaRepository = faixaRepository;
        }

        [HttpGet("disco/{idDisco}")]
        public async Task<ActionResult<IEnumerable<Faixa>>> GetByDisco(int idDisco)
        {
            var faixas = await _faixaRepository.GetByDisco(idDisco);
            return Ok(faixas);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Add(Faixa faixa)
        {
            var result = await _faixaRepository.Add(faixa);
            return CreatedAtAction(nameof(GetByDisco), new { idDisco = faixa.IdDisco }, faixa);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<int>> Update(Faixa faixa)
        {
            var result = await _faixaRepository.Update(faixa);
            if (result == 0)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await _faixaRepository.Delete(id);
            if (result == 0)
                return NotFound();
            return NoContent();
        }
    }
}
