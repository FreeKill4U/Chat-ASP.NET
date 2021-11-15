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
        private readonly IUserService _userService;

        public ChatController(IChatService chatService, IMapper mapper, IUserService userService)
        {
            _chatService = chatService;
            _mapper = mapper;
            _userService = userService;
        }

        

        [HttpPost("CreateChat")]
        public IActionResult CreateChat([FromBody]CreateChatDto model)
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var chat = _mapper.Map<Chat>(model);
            var userId = int.Parse(HttpContext.User.Identity.Name);
            _chatService.Create(chat, userId);
            return Created("New chat was created!", null);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody]AddUserDto addUser)
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var userId = int.Parse(HttpContext.User.Identity.Name);
            if (!_chatService.UserInChat(addUser.ChatId, userId))
                return Unauthorized("You don't belong to this chat!");
            _chatService.Join(addUser.ChatId, _userService.GetByNick(addUser.UserNick).Id);
            return Ok("You have successfully joined the chat!");
        }

        [HttpGet("GetMyChats")]
        public IActionResult GetMyChat()
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");

            var userId = int.Parse(HttpContext.User.Identity.Name);

            var chats = _chatService.GetAllChats(userId);

            var models = _mapper.Map<List<ChatInfo>>(chats);

            return Ok(models);
        }

        [HttpPost("LeaveChat/{chatId}")]
        public IActionResult LeaveChat([FromRoute] int chatId)
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var userId = int.Parse(HttpContext.User.Identity.Name);
            _chatService.Leave(chatId, userId);
            return Ok("You have successfully leaved the chat!");
        }

        [HttpPost("Send/{chatId}")]
        public IActionResult SendMessege([FromBody] MessageSendDto model, [FromRoute] int chatId)
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var messege = _mapper.Map<Message>(model);
            var userId = int.Parse(HttpContext.User.Identity.Name);

            _chatService.SendMessege(messege, chatId, userId);

            return Created("You have successfully send Messege!", null);
        }

        [HttpPost("ShowChat/{chatId}")]
        public IActionResult ShowChat([FromRoute] int chatId, [FromQuery] int part)
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var messeges = _chatService.ShowChat(chatId, userId, part);
            return Ok(messeges);
        }

        [HttpGet("GetUsers/{chatId}")]
        public IActionResult GetUsers([FromRoute] int chatId)
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            if (!_chatService.UserInChat(chatId, int.Parse(HttpContext.User.Identity.Name)))
                return Unauthorized("You don't belong to this chat!");
            var models = _chatService.GetUsers(chatId);
            return Ok(models);
        }

        [HttpPost("EditChat/{chatId}")]
        public IActionResult EditChat([FromRoute] int chatId, [FromQuery] int part)
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var userId = int.Parse(HttpContext.User.Identity.Name);
            var messeges = _chatService.ShowChat(chatId, userId, part);
            return Ok(messeges);
        }


        //Helper
        [HttpGet]
        public IActionResult GetName()
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var user = HttpContext.User.Identity.Name;
            return Ok(user);
        }
    }
}
