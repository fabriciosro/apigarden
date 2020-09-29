using System;
using Garden.Domain.Interfaces;
using Garden.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Aplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TreeController : Controller
    {
        private readonly IServiceTree _serviceTree;

        public TreeController(IServiceTree serviceTree) =>
            _serviceTree = serviceTree;

        [HttpPost]
        public IActionResult Register([FromBody] CreateTreeModel treeModel)
        {
            try
            {
                var tree = _serviceTree.Insert(treeModel);

                return Ok(tree?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateTreeModel treeModel)
        {
            try
            {
                var tree = _serviceTree.Update(id, treeModel);

                return Ok(tree);
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
                _serviceTree.Delete(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult RecoverAll()
        {
            try
            {
                var tree = _serviceTree.RecoverAll();
                return Ok(tree);
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
                var tree = _serviceTree.RecoverById(id);
                return Ok(tree);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}