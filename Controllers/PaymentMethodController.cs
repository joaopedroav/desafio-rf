using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechSub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _service;

        public PaymentMethodController(IPaymentMethodService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<PaymentMethod> CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            _service.SavePaymentMethod(paymentMethod);
            return CreatedAtAction(nameof(CreatePaymentMethod), new { id = paymentMethod.Id }, paymentMethod);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<PaymentMethod> GetPaymentMethodByIdAsync(Guid id)
        {
            return Ok(_service.GetPaymentMethodByIdAsync(id));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<PaymentMethod>>> GetAllPaymentMethodsAsync()
        {
            var PaymentMethods = await _service.GetAllPaymentMethodsAsync();
            return Ok(PaymentMethods);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePaymentMethod(Guid id)
        {
            await _service.DeletePaymentMethodByIdAsync(id);

            return Ok();
        }
    }
}
