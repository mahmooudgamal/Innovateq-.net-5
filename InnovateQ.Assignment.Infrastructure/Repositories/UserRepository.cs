using InnovateQ.Assignment.Core.Repositories;
using InnovateQ.Assignment.Infrastructure.Data.EntityFramework;
using InnovateQ.Assignment.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Infrastructure.Repositories
{
    public class UserRepository : Repository<InnovateQ.Assignment.Core.Entities.User>, IUserRepository
    {
        public UserRepository(InnovateqContext innovateqContext) : base(innovateqContext)
        {

        }
        public async Task<IEnumerable<Core.Entities.User>> GetUserByName(string lastname)
        {
            return await _innovateqContext.AppUsers
                .Where(m => m.Name == lastname)
                .ToListAsync();
        }
    }
}
