using AutoMapper;
using InnovateQ.Assignment.Core.Entities;
using InnovateQ.Assignment.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<IdentityUser, AppUser>().ConstructUsing(u => new AppUser { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName, PasswordHash = u.PasswordHash });
            CreateMap<AppUser, IdentityUser>().ConstructUsing(au => new IdentityUser(au.FirstName, au.LastName, au.Email, au.UserName, au.Id, au.PasswordHash));

        }
    }
}
