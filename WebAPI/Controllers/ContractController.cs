using Microsoft.AspNetCore.Mvc;
using Services;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("contracts")]
    //[Authorize(Roles.SUPER_ADMIN)]
    //[Authorize(Roles.DIRECTOR)]
    //[Authorize(Roles.MANAGER)]

    public class ContractController : ControllerBase
    {
        private readonly ContractService _contractService;

        public ContractController(ContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<ActionResult<GetContractResponse>> GetAllContracts()
        {
            var contracts = await _contractService.GetAllContractsAsync();
            return Ok(contracts);
        }

        [HttpGet]
        [Route("client/{clientId:Guid}")]
        public async Task<ActionResult<GetContractResponse>> GetAllContractsByClient([Required] Guid clientId)
        {
            var contracts = await _contractService.GetAllContractsByClientAsync(clientId);
            return Ok(contracts);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<GetContractResponse>> GetContractById([Required] Guid id)
        {
            var contract = await _contractService.GetContractByIdAsync(id);
            return Ok(contract);
        }

        [HttpPost]
        public async Task<ActionResult<CreateContractResponse>> CreateContract([FromQuery][FromBody] CreateContractRequest request)
        {
            var contract = await _contractService.CreateContractAsync(request);
            return Ok(contract);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<ActionResult<UpdateContractResponse>> UpdateContract([Required] Guid id, [FromQuery][FromBody] UpdateContractRequest request)
        {
            var contract = await _contractService.UpdateContractAsync(id, request);
            return Ok(contract);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<ActionResult> DeleteContract([Required] Guid id)
        {
            await _contractService.DeleteContractAsync(id);
            return NoContent();
        }
    }
}
