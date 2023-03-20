using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealTimeEventService.Api.Hubs;

namespace RealTimeEventService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IHubContext<EventHub> eventHub;

        public GroupsController(IHubContext<EventHub> eventHub)
        {
            this.eventHub = eventHub;
        }

        [HttpPost("group/create")]
        public async Task<IActionResult> CreateGroup([FromQuery] string groupName)
        {
            await this.eventHub.Groups.AddToGroupAsync(Guid.NewGuid().ToString(), groupName);
            return Ok();
        }        
    }
}
