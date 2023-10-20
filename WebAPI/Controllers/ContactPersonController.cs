using DAL.Constant;
using Domain.Services.ContactPersonService;
using Domain.Services.ContactPersonService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("contactpersons")]
    [Authorize(Roles.SUPER_ADMIN)]
    [Authorize(Roles.DIRECTOR)]
    [Authorize(Roles.MANAGER)]

    public class ContactPersonController : ControllerBase
    {
        private readonly ContactPersonService _contactPersonService;

        public ContactPersonController(ContactPersonService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetContactPersonResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetContactPersonResponse>> GetAllContactPersons()
        {
            var contactPersons = await _contactPersonService.GetAllContactPersonsAsync();
            return Ok(contactPersons);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetContactPersonResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetContactPersonResponse>> GetContactPersonById([Required] Guid id)
        {
            var contactPerson = await _contactPersonService.GetContactPersonByIdAsync(id);
            return Ok(contactPerson);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(CreateContactPersonResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<CreateContactPersonResponse>> CreateContactPerson([FromBody] CreateContactPersonRequest request)
        {
            var contactPerson = await _contactPersonService.CreateContactPersonAsync(request);
            return Ok(contactPerson);
        }

        [HttpPut("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(UpdateContactPersonResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<UpdateContactPersonResponse>> UpdateContactPerson([Required] Guid id, [FromBody] UpdateContactPersonRequest request)
        {
            var contactPerson = await _contactPersonService.UpdateContactPersonAsync(id, request);
            return Ok(contactPerson);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult> DeleteContactPerson([Required] Guid id)
        {
            await _contactPersonService.DeleteContactPersonAsync(id);
            return NoContent();
        }
    }
}
