using Domain.Services.ContractService;
using Domain.Services.ContractService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("contracts")]
    [AllowAnonymous]
    public class ContractController : ControllerBase
    {
        private readonly ContractService _contractService;

        public ContractController(ContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetContractResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetContractResponse>> GetAllContracts()
        {
            var contracts = await _contractService.GetAllContractsAsync();
            return Ok(contracts);
        }

        [HttpGet("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetContractResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetContractResponse>> GetContractById([Required] Guid id)
        {
            var contract = await _contractService.GetContractByIdAsync(id);
            return Ok(contract);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(CreateContractResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<CreateContractResponse>> CreateContract([FromBody] CreateContractRequest request)
        {
            var contract = await _contractService.CreateContractAsync(request);
            return Ok(contract);
        }

        [HttpPut("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(UpdateContractResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<UpdateContractResponse>> UpdateContract([Required] Guid id, [FromBody] UpdateContractRequest request)
        {
            var contract = await _contractService.UpdateContractAsync(id, request);
            return Ok(contract);
        }

        [HttpDelete("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult> DeleteContract([Required] Guid id)
        {
            await _contractService.DeleteContractAsync(id);
            return NoContent();
        }
    }
}
