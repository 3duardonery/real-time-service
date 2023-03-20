using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RealTimeEventService.Api.Hubs;
using RealTimeEventService.Api.Models;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace RealTimeEventService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IHubContext<EventHub> eventHub;
        private string SEND_TO_GROUP = "sendtogroup";

        public EventsController(IHubContext<EventHub> eventHub)
        {
            this.eventHub = eventHub;
        }

        [HttpPost("group/{groupName}")]
        public async Task<IActionResult> SendMessageToGroupByName([FromRoute] string groupName, [FromBody] Event eventDetails)
        {            
            await eventHub.Clients.Groups(groupName).SendAsync(SEND_TO_GROUP, JsonConvert.SerializeObject(eventDetails));

            return Ok();
        }        
    }
}
