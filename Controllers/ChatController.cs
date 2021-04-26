using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Models.Chat;
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
        public IActionResult CreateChat(CreateChatDto model)
        {
            var chat = _mapper.Map<Chat>(model);
            var user = HttpContext.User.Identity.Name;
            var result = _chatService.Create(chat, int.Parse(user));
            return Ok(result);
        }
    }
}
