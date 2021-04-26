using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SzkolaKomunikator.Entity;
using SzkolaKomunikator.Models;
using SzkolaKomunikator.Models.Chat;

namespace SzkolaKomunikator.Helper.Maps
{
    public class CommunicatorMapper : Profile
    {
        public CommunicatorMapper()
        {
            CreateMap<RegisterDto, User>().
                ForMember(m => m.Nick, c => c.MapFrom(s => s.Nick));
            CreateMap<CreateChatDto, Chat>().
                ForMember(m => m.Name, c => c.MapFrom(s => s.Name));
        }
    }
}
