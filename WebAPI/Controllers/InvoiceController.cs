using DAL.Constant;
using Domain.Services.InvoiceService;
using Domain.Services.InvoiceServices.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("invoices")]
    [Authorize(Roles.SUPER_ADMIN)]
    [Authorize(Roles.DIRECTOR)]
    [Authorize(Roles.MANAGER)]
    [Authorize(Roles.ACCOUNTANT)]

    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetInvoiceResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetInvoiceResponse>> GetAllInvoices()
        {
            var invoices = await _invoiceService.GetAllInvoicesAsync();
            return Ok(invoices);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(GetInvoiceResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<GetInvoiceResponse>> GetInvoiceById([Required] Guid id)
        {
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id);
            return Ok(invoice);
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(CreateInvoiceResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<CreateInvoiceResponse>> CreateInvoice([FromBody] CreateInvoiceRequest request)
        {
            var invoice = await _invoiceService.CreateInvoiceAsync(request);
            return Ok(invoice);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Success", typeof(UpdateInvoiceResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult<UpdateInvoiceResponse>> UpdateInvoice([Required] Guid id, [FromBody] UpdateInvoiceRequest request)
        {
            var invoice = await _invoiceService.UpdateInvoiceAsync(id, request);
            return Ok(invoice);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request", typeof(ErrorResponse))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal server error", typeof(ErrorResponse))]
        public async Task<ActionResult> DeleteInvoice([Required] Guid id)
        {
            await _invoiceService.DeleteInvoiceAsync(id);
            return NoContent();
        }
    }
}
