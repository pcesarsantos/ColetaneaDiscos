using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ColetaneaDiscos.Models;
using ColetaneaDiscos.Repositories;
using System.ComponentModel;

namespace ColetaneaDiscos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscoController : ControllerBase
    {
        private readonly IDiscoRepository _discoRepository;

        public DiscoController(IDiscoRepository discoRepository)
        {
            _discoRepository = discoRepository;
        }

        [HttpGet]
       public async Task<ActionResult<IEnumerable<Disco>>> GetAll()
       {
            var discos = await _discoRepository.GetAll();
            return Ok(discos);
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Disco>> GetById(int id)
       {
            var disco = await _discoRepository.GetById(id);
            if( disco == null)
                return NotFound();
            return Ok(disco);
       }

       [HttpGet("genero/{genero}")]
       public async Task<ActionResult<IEnumerable<Disco>>> GetByGenero(string genero)
       {
            var discos = await _discoRepository.GetByGenero(genero);
            return Ok(discos);
       }

       [HttpGet("artista/{artista}")]
       public async Task<ActionResult<IEnumerable<Disco>>> GetByArtista(string artista)
       {
            var discos = await _discoRepository.GetByArtista(artista);
            return Ok(discos);
       }

       [HttpPost]
        public async Task<ActionResult<int>> Add(Disco disco)
        {
            var result = await _discoRepository.Add(disco);
            return CreatedAtAction(nameof(GetById), new { id = result }, disco);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(Disco disco)
        {
            var result = await _discoRepository.Update(disco);
            if (result == 0)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var result = await _discoRepository.Delete(id);
            if (result == 0)
                return NotFound();
            return NoContent();
        }
    }

}