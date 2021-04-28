using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Models;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Models;
using AutoMapper;
using SzkolaKomunikator.Helpers.Exceptions;

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
            var user = _userService.Authenticate(model.Nick, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto model)
        {

            var user = _mapper.Map<User>(model);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            if(_userService.Create(user))
                return Ok(user);

            else return BadRequest(new { message = "Something went wrong" });
        }


        //Test Action

        [AllowAnonymous]
        [HttpGet("Exception")]
        public IActionResult Test()
        {
            throw new NotFoundException("Test");
        }

        [HttpGet("Name")]
        public IActionResult GetName()
        {
            var user = HttpContext.User.Identity.Name;
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user =  _userService.GetById(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
