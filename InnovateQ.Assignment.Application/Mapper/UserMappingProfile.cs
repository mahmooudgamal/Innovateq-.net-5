using AutoMapper;
using InnovateQ.Assignment.Application.Commands;
using InnovateQ.Assignment.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<InnovateQ.Assignment.Core.Entities.User, UserResponse>().ReverseMap();
            CreateMap<InnovateQ.Assignment.Core.Entities.User, CreateUserCommand>().ReverseMap();
        }
    }
}
