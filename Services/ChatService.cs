using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Helpers.Exceptions;
using SzkolaKomunikator.Models.Chat;
using SzkolaKomunikator.Models.Chats;

namespace SzkolaKomunikator.Services
{
    public interface IChatService
    {
        void Create(Chat chat, int userId);
        void Join(int chatId, int userId);
        void Leave(int chatId, int userId);
        void SendMessege(Messege messege, int chatId, int userId);
        IEnumerable<ShowMessegeDto> ShowChat(int chatId, int userId, int part);
    }

    public class ChatService : IChatService
    {
        private readonly CommunicatorDbContext _dbContext;
        private readonly IMapper _mapper;

        public ChatService(CommunicatorDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Create(Chat chat, int userId)
        {
            var user = _dbContext.Users.SingleOrDefault(r => r.Id == userId);
            if (user == null)
                throw new IncorrectDataException("User not exist");
            chat.Users = new List<User> { user };

            _dbContext.Chats.Add(chat);
            _dbContext.SaveChanges();
        }

        public void Join(int chatId, int userId)
        {
            var chat = _dbContext.Chats.SingleOrDefault(r => r.Id == chatId);
            if (chat == null)
                throw new IncorrectDataException("Chat not exist");

            var user = _dbContext.Users.SingleOrDefault(r => r.Id == userId);
            if (user == null)
                throw new IncorrectDataException("User not exist");

            chat.Users = new List<User> { user };
            _dbContext.SaveChanges();
        }

        public void Leave(int chatId, int userId)
        {
            var chat = _dbContext.Chats
                .Include(r => r.Users)
                .FirstOrDefault(a => a.Id == chatId);

            var data = chat.Users;

            chat.Users.Remove(_dbContext.Users.Single(a => a.Id == userId));

            _dbContext.SaveChanges();
        }

        public void SendMessege(Messege messege, int chatId, int userId)
        {
            if (!UserInChat(chatId, userId))
                throw new UnauthorizeException("The user does not belong to a chat!");

            var chat = _dbContext.Chats
                .Include(r => r.Messeges)
                .FirstOrDefault(a => a.Id == chatId);

            if (chat == null)
                throw new NotFoundException("Chat does not exist!");

            messege.Date = DateTime.Now;
            messege.Chat = GetChatById(chatId);
            messege.AuthorId = userId;

            chat.Messeges.Add(messege);

            _dbContext.SaveChanges();
        }

        public IEnumerable<ShowMessegeDto> ShowChat(int chatId, int userId, int part)
        {
            if (!UserInChat(chatId, userId))
                throw new UnauthorizeException("The user does not belong to a chat!");

            var chat = _dbContext.Chats
                .Include(r => r.Messeges)
                .Include(r => r.Users)
                .FirstOrDefault(a => a.Id == chatId);
            if (chat == null)
                throw new NotFoundException("Chat does not exist!");

            var messeges = chat.Messeges.ToList().Skip(50*(part-1)).Take(50);

            var models = _mapper.Map<List<ShowMessegeDto>>(messeges);

            return models;
        }





        //Helpers function
        private Chat GetChatById(int chatId)
        {
            var result = _dbContext.Chats.FirstOrDefault(r => r.Id == chatId);
            return result;
        }

        private bool UserInChat(int chatId, int userId)
        {
            var chat = _dbContext.Chats.Include(r => r.Users).FirstOrDefault(r => r.Id == chatId);
            var user = chat.Users.FirstOrDefault(r => r.Id == userId);

            if (user == null)
                return false;

            return true;
        }

        
    }
}
