using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Helpers.Exceptions;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User GetById(int id);
        User GetByNick(string nick);
        bool Create(User newUser);

        bool AuthFirst(string token);
    }

    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly CommunicatorDbContext _dbContext;

        public UserService(IOptions<AppSettings> appSettings, CommunicatorDbContext dbContext)
        {
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
        }

        public User Authenticate(string username, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Nick == username && x.Password == password);

            // return null if user not found
            if (user == null)
                throw new NotFoundException("Username or password is incorrect");

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            _dbContext.SaveChanges();


            return user;
        }

        public bool Create(User newUser)
        {
            newUser.Color = "#3ad192";
            newUser.Icon = 1;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Remove(User newUser)
        {
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            return true;
        }

        //Helper functions
        public static string GetUserName(int Id)
        {
            using (var db = new CommunicatorDbContext())
            {
                var user = db.Users
                .FirstOrDefault(r => r.Id == Id).Nick;
                return user;
            }
        }

        public User GetById(int id) 
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }
        public User GetByNick(string nick)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Nick == nick);
            return user;
        }

        public bool AuthFirst(string id)
        {
            if (_dbContext.Users.FirstOrDefault(x => x.Id == int.Parse(id)) != null)
                return true;
            else return false;
        }
    }
}