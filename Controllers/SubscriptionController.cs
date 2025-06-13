using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechSub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;

        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<Subscription> CreateSubscription(Subscription subscription)
        {
            _service.SaveSubscription(subscription);
            return CreatedAtAction(nameof(CreateSubscription), new { id = subscription.Id }, subscription);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<Subscription> GetSubscriptionByIdAsync(Guid id)
        {
            return Ok(_service.GetSubscriptionByIdAsync(id));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> GetAllSubscriptionsAsync()
        {
            var Subscriptions = await _service.GetAllSubscriptionsAsync();
            return Ok(Subscriptions);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubscription(Guid id)
        {
            await _service.DeleteSubscriptionByIdAsync(id);

            return Ok();
        }

        [Authorize]
        [HttpPost("cancel")]
        public ActionResult<Subscription> CancelSubscription(Guid id)
        {
            return Ok(_service.CancelSubscription(id));
        }

        [Authorize]
        [HttpGet("report/getMonthlyRevenue")]
        public ActionResult<IEnumerable<RevenueReport>> GetMonthlyRevenue()
        {
            return Ok(_service.GetMonthlyRevenue());
        }
    }
}
