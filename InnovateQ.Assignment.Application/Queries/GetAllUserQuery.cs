using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Queries
{
    public class GetAllUserQuery : IRequest<List<InnovateQ.Assignment.Core.Entities.User>>
    {

    }
}
