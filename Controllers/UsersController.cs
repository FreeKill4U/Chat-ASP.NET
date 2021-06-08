using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Models;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Models;
using AutoMapper;
using SzkolaKomunikator.Helpers.Exceptions;
using Microsoft.Net.Http.Headers;
using SzkolaKomunikator.Models.User;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody]AuthenticateDto model)
        {
            if (model == null || model.Nick == "")
                return BadRequest("Username or password is incorrect");

            var user = _userService.Authenticate(model.Nick, model.Password);

            var modelRequest = _mapper.Map<ReturnUserDto>(user);

            if (user == null)
                return BadRequest("Username or password is incorrect");

            return Ok(modelRequest);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto model)
        {

            var user = _mapper.Map<User>(model);

            if (_userService.GetByNick(model.Nick) != null)
                throw new ThisUserExistsException("User with this nick exist!");

            if (user == null)
                return BadRequest("Username or password is incorrect");

            var modelRequest = _mapper.Map<ReturnUserDto>(user);

            if (_userService.Create(user))
                return Ok(modelRequest);

            else return BadRequest("Something went wrong");
        }


        //Test Action

        [AllowAnonymous]
        [HttpGet("Exception")]
        public IActionResult Test()
        {
            throw new NotFoundException("Test");
        }



        

        //Helper function
        [HttpGet]
        public IActionResult GetById()
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var currentUserId = getAuthorizeId();

            var user =  _userService.GetById(currentUserId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }


        [HttpGet("Name")]
        public IActionResult GetName()
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            var user = _userService.GetById(int.Parse(HttpContext.User.Identity.Name));
            var modelRequest = _mapper.Map<ReturnUserDto>(user);
            return Ok(user);
        }
        private int getAuthorizeId()
        {
            return int.Parse(User.Identity.Name);
        }

        [HttpGet("SendToken")]
        public IActionResult SendToken()
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            return Ok(new Message()
            {
                Text = "Siema"
            });
        }

        [HttpGet("CheckToken")]
        public IActionResult CheckToken()
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            return Ok();
        }

        [HttpGet("Auth")]
        public IActionResult authTest()
        {
            if (!_userService.AuthFirst(User.Identity.Name))
                return Unauthorized("Session lost!");
            return Ok(User.Identity.Name);
        }
    }
}
