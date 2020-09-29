using System;
using System.Threading.Tasks;
using Garden.Domain.Interfaces;
using Garden.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Aplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecieController : Controller
    {
        private readonly IServiceSpecie _serviceSpecie;

        public SpecieController(IServiceSpecie serviceSpecie) =>
            _serviceSpecie = serviceSpecie;

        [HttpPost]
        public IActionResult Register([FromBody] CreateSpecieModel specieModel)
        {
            try
            {
                var harvest = _serviceSpecie.Insert(specieModel);

                return Ok(harvest?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateSpecieModel specieModel)
        {
            try
            {
                var specie = _serviceSpecie.Update(id, specieModel);

                return Ok(specie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            try
            {
                _serviceSpecie.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> RecoverAll()
        {
            try
            {
                var specie = await _serviceSpecie.GetAllAsync();
                return Ok(specie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Recover([FromRoute] int id)
        {
            try
            {
                var specie = _serviceSpecie.RecoverById(id);
                return Ok(specie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}