using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Models.Chats;
using SzkolaKomunikator.SignalR;
using WebApi.Services;

namespace SzkolaKomunikator.Controllers
{
    [Authorize]
    [Route("Broadcast")]
    public class BroadcastController : Hub
    {
        private readonly IHubContext<MessageHub, IMessageHubClient> _hubContext;
        private CommunicatorDbContext _dbcontext;
        private IMapper _mapper;

        public BroadcastController(IHubContext<MessageHub, IMessageHubClient> hubContext, CommunicatorDbContext dbcontext, IMapper mapper)
        {
            _hubContext = hubContext;
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("send")]
        public async void SendMessage(MessageSendDto message, int chatId)
        {
            var chat = _dbcontext.Chats
                .Include(c => c.Messeges)
                .FirstOrDefault(r => r.Id == chatId);


           // var model = _mapper.Map<Message>(message);
            //model.AuthorId = int.Parse(Context.User.Identity.Name);
            //model.Date = DateTime.Now;
            //chat.Messeges.Add(model);
           // _dbcontext.SaveChanges();
            await Clients.Group(chat.Name).SendAsync("Send", message);
        }

        [HttpGet]
        [Route("AddToGroup")]
        public async void AddToGroup()
        {
            var user = _dbcontext.Users
                .Include(c => c.Chats)
                .FirstOrDefault(r => r.Id == int.Parse(Context.User.Identity.Name));
            foreach (var chat in user.Chats)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chat.Name);
            }
        }
    }
}
