using InnovateQ.Assignment.Application.Commands;
using InnovateQ.Assignment.Application.Mapper;
using InnovateQ.Assignment.Application.Responses;
using InnovateQ.Assignment.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Handlers.CommandHandlers
{

    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepo;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = UserMapper.Mapper.Map<InnovateQ.Assignment.Core.Entities.User>(request);
            if(userEntity is null)
            {
                throw new ApplicationException("Issue with mapper");
            }
            var newUser = await _userRepo.AddAsync(userEntity);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(newUser);
            return userResponse;
        }
    }
}
