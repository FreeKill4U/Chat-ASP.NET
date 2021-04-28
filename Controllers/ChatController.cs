using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Models.Chat;
using SzkolaKomunikator.Models.Chats;
using SzkolaKomunikator.Services;
using WebApi.Services;

namespace SzkolaKomunikator.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Chat")]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatController(IChatService userService, IMapper mapper)
        {
            _chatService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetName()
        {
            var user = HttpContext.User.Identity.Name;
            return Ok(user);
        }

        [HttpPost("CreateChat")]
        public IActionResult CreateChat([FromBody]CreateChatDto model)
        {
            var chat = _mapper.Map<Chat>(model);
            var userId = int.Parse(HttpContext.User.Identity.Name);
            _chatService.Create(chat, userId);
            return Created("New chat was created!", null);
        }

        [HttpGet("JoinChat/{chatId}")]
        public IActionResult JoinChat([FromRoute]int chatId)
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            _chatService.Join(chatId, userId);
            return Ok("You have successfully joined the chat!");
        }

        [HttpGet("LeaveChat/{chatId}")]
        public IActionResult LeaveChat([FromRoute] int chatId)
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            _chatService.Leave(chatId, userId);
            return Ok("You have successfully leaved the chat!");
        }

        [HttpPost("Send/{chatId}")]
        public IActionResult SendMessege([FromBody] MessegeSendDto model, [FromRoute] int chatId)
        {
            var messege = _mapper.Map<Messege>(model);
            var userId = int.Parse(HttpContext.User.Identity.Name);

            _chatService.SendMessege(messege, chatId, userId);

            return Created("You have successfully send Messege!", null);
        }

        [HttpPost("ShowChat/{chatId}")]
        public IActionResult ShowChat([FromRoute] int chatId, [FromQuery] int part)
        {
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var messeges = _chatService.ShowChat(chatId, userId, part);
            return Ok(messeges);
        }
    }
}
