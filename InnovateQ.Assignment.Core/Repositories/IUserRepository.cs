using InnovateQ.Assignment.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Core.Repositories
{
    public interface IUserRepository : IRepository<InnovateQ.Assignment.Core.Entities.User>
    {
        //custom operations here
        Task<IEnumerable<InnovateQ.Assignment.Core.Entities.User>> GetUserByName(string lastname);
    }
}
