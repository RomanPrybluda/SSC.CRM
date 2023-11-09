using Microsoft.AspNetCore.Mvc;
using Services;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("clients")]
    //[Authorize(Roles.SUPER_ADMIN)]
    //[Authorize(Roles.DIRECTOR)]
    //[Authorize(Roles.MANAGER)]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]


    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetClientResponse))]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientService.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet, Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetClientResponse))]
        public async Task<IActionResult> GetClientById([Required] Guid id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            return Ok(client);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(CreateClientResponse))]
        public async Task<IActionResult> CreateClient([FromQuery][FromBody] CreateClientRequest request)
        {
            var client = await _clientService.CreateClientAsync(request);
            return Ok(client);
        }

        [HttpPut, Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(UpdateClientResponse))]
        public async Task<IActionResult> UpdateClient([Required] Guid id, [FromQuery][FromBody] UpdateClientRequest request)
        {
            var client = await _clientService.UpdateClientAsync(id, request);
            return Ok(client);
        }

        [HttpDelete, Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success")]
        public async Task<IActionResult> DeleteClient([Required] Guid id)
        {
            await _clientService.DeleteClientAsync(id);
            return Ok();
        }
    }
}