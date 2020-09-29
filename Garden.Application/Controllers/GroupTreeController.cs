using System;
using Garden.Domain.Interfaces;
using Garden.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garden.Aplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupTreeController : Controller
    {
        private readonly IServiceGroupTree _serviceGroupTree;

        public GroupTreeController(IServiceGroupTree serviceGroupTree) =>
            _serviceGroupTree = serviceGroupTree;

        [HttpPost]
        public IActionResult Register([FromBody] CreateGroupTreeModel GroupTreeModel)
        {
            try
            {
                var harvest = _serviceGroupTree.Insert(GroupTreeModel);

                return Ok(harvest?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateGroupTreeModel GroupTreeModel)
        {
            try
            {
                var GroupTree = _serviceGroupTree.Update(id, GroupTreeModel);

                return Ok(GroupTree);
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
                _serviceGroupTree.Delete(id);

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
                var GroupTree = _serviceGroupTree.RecoverAll();
                return Ok(GroupTree);
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
                var GroupTree = _serviceGroupTree.RecoverById(id);
                return Ok(GroupTree);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}