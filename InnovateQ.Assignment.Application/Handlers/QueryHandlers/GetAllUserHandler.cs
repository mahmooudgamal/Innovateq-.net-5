using InnovateQ.Assignment.Application.Queries;
using InnovateQ.Assignment.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Handlers.QueryHandlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, List<InnovateQ.Assignment.Core.Entities.User>>
    {
        private readonly IUserRepository _userRepo;

        public GetAllUserHandler(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public async Task<List<Core.Entities.User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return (List<Core.Entities.User>)await _userRepo.GetAllAsync();
        }
    }
}
