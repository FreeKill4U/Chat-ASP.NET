using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SzkolaKomunikator.SignalR;

namespace SzkolaKomunikator.Controllers
{
    [Authorize]
    [Route("Broadcast")]
    public class BroadcastController : Controller
    {
        private readonly IHubContext<MessageHub, IMessageHubClient> _hubContext;

        public BroadcastController(IHubContext<MessageHub, IMessageHubClient> hubContext)
        {
            _hubContext = hubContext;
        }
        [HttpGet]
        [Route("send")]
        public void SendMessage(string user, string message)
        {
            _hubContext.Clients.All.BroadcastMessage(message);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult get()
        {
            return Ok("Ok");
        }
    }
}
