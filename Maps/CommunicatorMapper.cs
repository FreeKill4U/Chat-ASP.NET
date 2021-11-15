using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Models;
using SzkolaKomunikator.Models.Chat;
using SzkolaKomunikator.Models.Chats;
using SzkolaKomunikator.Models.User;
using WebApi.Services;

namespace SzkolaKomunikator.Helper.Maps
{
    public class CommunicatorMapper : Profile
    {
        public CommunicatorMapper()
        {
            CreateMap<RegisterDto, User>().
                ForMember(m => m.Nick, c => c.MapFrom(s => s.Nick));
            CreateMap<User, ReturnUserDto>().
                ForMember(m => m.Nick, c => c.MapFrom(s => s.Nick));
            CreateMap<User, UserInfoDto>().
                ForMember(m => m.Nick, c => c.MapFrom(s => s.Nick));


            CreateMap<CreateChatDto, Chat>().
                ForMember(m => m.Name, c => c.MapFrom(s => s.Name));
            CreateMap<Chat, ChatInfo>().
                ForMember(m => m.Name, c => c.MapFrom(s => s.Name));

            CreateMap<MessageSendDto, Message>().
                ForMember(m => m.Text, c => c.MapFrom(s => s.Text));
            CreateMap<Message, ShowMessageDto>()
                .ForMember(m => m.Author, c => c.MapFrom(s => UserService.GetUserName(s.AuthorId)))
                .ForMember(m => m.ChatId, c => c.MapFrom(s => s.Chat.Id));
        }
    }
}
