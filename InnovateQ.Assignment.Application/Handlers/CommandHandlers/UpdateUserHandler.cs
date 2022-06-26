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

    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserResponse>
    {
        private readonly IUserRepository _userRepo;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }
        public async Task<UserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = await _userRepo.GetByIdAsync(request.Id);
            if(userEntity is null)
            {
                throw new ApplicationException("userEntity not found");
            }
            userEntity.Name = request.Name;
            userEntity.State = request.State;
            userEntity.Street = request.Street;
            userEntity.PinCode = request.PinCode;
            userEntity.Country = request.Country;
            userEntity.Designation = request.Designation;
            await _userRepo.UpdateAsync(userEntity);
            var userResponse = UserMapper.Mapper.Map<UserResponse>(userEntity);
            return userResponse;
        }
    }
}
