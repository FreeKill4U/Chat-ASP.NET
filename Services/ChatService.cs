using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Models.Chat;

namespace SzkolaKomunikator.Services
{
    public interface IChatService
    {
        int Create(Chat chat, int userId);
        bool Join(int Id);
    }

    public class ChatService : IChatService
    {
        private readonly CommunicatorDbContext _dbContext;

        public ChatService(CommunicatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Chat chat, int userId)
        {
            var user = _dbContext.Users.SingleOrDefault(r => r.Id == userId);
            chat.Users = new List<User> { user };

            _dbContext.Chats.Add(chat);
            _dbContext.SaveChanges();

            return _dbContext.Chats.SingleOrDefault(r => r.Name == chat.Name).Users.SingleOrDefault(r => r.Id == userId).Id;
        }

        public bool Join(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
