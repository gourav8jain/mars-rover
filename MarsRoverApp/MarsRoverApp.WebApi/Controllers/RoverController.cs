using System.Net;
using MarsRoverApp.Common.Infrastructure.Common.Interfaces;
using MarsRoverApp.Common.Infrastructure.Common.Models;
using MarsRoverApp.Common.Infrastructure.Common.ViewModels;
using MarsRoverApp.WebApi.Implementation.Filters;
using MarsRoverApp.WebApi.Implementation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MarsRoverApp.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private readonly IRoverCaching _roverCaching;
        private readonly IRover _rover;
        public RoverController(IRoverCaching roverCaching, IRover rover)
        {
            this._roverCaching = roverCaching;
            this._rover = rover;
        }

        // GET api/values/5
        [Route("rover/{id}")]
        [HttpGet]
        public RoverViewModel Get(int id)
        {
            return (RoverViewModel)_roverCaching.GetItem(id);
        }

        // POST api/values
        [Route("rover")]
        [HttpPost]
        public IActionResult Create([FromBody] RoverModel model)
        {
            if (!_roverCaching.IsItemExists(model.Id))
            {
                var roverViewModel = new RoverViewModel
                {
                    Id = model.Id,
                    Name = model.Name
                };
                _roverCaching.SetItem(model.Id, roverViewModel);
            }

            return CreatedAtAction(nameof(Create), new { id = model.Id }, model);
        }

        // POST api/values
        [Route("rover")]
        [HttpPut]
        public IActionResult Rename([FromBody] RoverModel model)
        {
            if (_roverCaching.IsItemExists(model.Id))
            {
                var roverViewModel = Get(model.Id);
                roverViewModel.Name = model.Name;
                _roverCaching.Remove(model.Id);
                _roverCaching.SetItem(model.Id, roverViewModel);
            }

            return NoContent();
        }
        // POST api/values
        [ServiceFilter(typeof(InputValidationFilter))]
        [Route("rover/move")]
        [HttpPost]
        public RoverViewModel Move([FromBody] RoverModel model)
        {
            if (_roverCaching.IsItemExists(model.Id))
            {
                var result = _rover.Process(Get(model.Id), model.MovementInstruction);
                _roverCaching.Remove(model.Id);
                _roverCaching.SetItem(model.Id, result);
            }

            return Get(model.Id);
        }
    }
}
