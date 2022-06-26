using AutoMapper;
using InnovateQ.Assignment.Application.Common.Mapping;
using InnovateQ.Assignment.Core.Entities;
using InnovateQ.Assignment.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Queries
{
    public class UserDto : IMapFrom<User>
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(src => UserExtensions.FullAddress(src)));
        }

    }
}
