using DesafioTechSub.IServices;
using DesafioTechSub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTechSub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _service;

        public SubscriptionPlanController(ISubscriptionPlanService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<SubscriptionPlan> CreateSubscriptionPlan(SubscriptionPlan subscriptionPlan)
        {
            _service.SaveSubscriptionPlan(subscriptionPlan);
            return CreatedAtAction(nameof(CreateSubscriptionPlan), new { id = subscriptionPlan.Id }, subscriptionPlan);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<SubscriptionPlan> GetSubscriptionPlanByIdAsync(Guid id)
        {
            return Ok(_service.GetSubscriptionPlanByIdAsync(id));
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<SubscriptionPlan>>> GetAllSubscriptionPlansAsync()
        {
            var SubscriptionPlans = await _service.GetAllSubscriptionPlansAsync();
            return Ok(SubscriptionPlans);
        }

        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSubscriptionPlan(Guid id)
        {
            await _service.DeleteSubscriptionPlanByIdAsync(id);

            return Ok();
        }
    }
}
