using Microsoft.AspNetCore.Mvc;
using Services;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("users")]
    //[Authorize(Roles.SUPER_ADMIN)]
    //[Authorize(Roles.DIRECTOR)]
    //[Authorize(Roles.MANAGER)]

    public class AppUserController : ControllerBase
    {
        private readonly AppUserService _appUserService;

        public AppUserController(AppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetAppUserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetAppUserResponse>> GetAllAppUsers()
        {
            var appUsers = await _appUserService.GetAllAppUsersAsync();
            return Ok(appUsers);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetAppUserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetAppUserResponse>> GetAppUserById([Required] Guid id)
        {
            var appUser = await _appUserService.GetAppUserByIdAsync(id);
            return Ok(appUser);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(CreateAppUserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<CreateAppUserResponse>> CreateAppUser([FromQuery][FromBody] CreateAppUserRequest request)
        {
            var appUser = await _appUserService.CreateAppUserAsync(request);
            return Ok(appUser);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(UpdateAppUserResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<UpdateAppUserResponse>> UpdateAppUser([Required] Guid id, [FromQuery][FromBody] UpdateAppUserRequest request)
        {
            var appUser = await _appUserService.UpdateAppUserAsync(id, request);
            return Ok(appUser);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult> DeleteAppUser([Required] Guid id)
        {
            await _appUserService.DeleteAppUserAsync(id);
            return NoContent();
        }
    }
}