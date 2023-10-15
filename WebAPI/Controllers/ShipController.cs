using Domain.Services.ShipService;
using Domain.Services.ShipService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("ships")]
    [AllowAnonymous]

    public class ShipController : ControllerBase
    {
        private readonly ShipService _shipService;

        public ShipController(ShipService shipService)
        {
            _shipService = shipService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetShipResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetShipResponse>> GetAllShips()
        {
            var ships = await _shipService.GetAllShipsAsync();
            return Ok(ships);
        }

        [HttpGet("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetShipResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetShipResponse>> GetShipById([Required] Guid id)
        {
            var ship = await _shipService.GetShipByIdAsync(id);
            return Ok(ship);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(CreateShipResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<CreateShipResponse>> CreateShip([FromQuery] CreateShipRequest request)
        {
            var ship = await _shipService.CreateShipAsync(request);
            return Ok(ship);
        }

        [HttpPut("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(UpdateShipResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<UpdateShipResponse>> UpdateShip([Required] Guid id, [FromQuery] UpdateShipRequest request)
        {
            var ship = await _shipService.UpdateShipAsync(id, request);
            return Ok(ship);
        }

        [HttpDelete("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult> DeleteShip([Required] Guid id)
        {
            await _shipService.DeleteShipAsync(id);
            return NoContent();
        }
    }
}