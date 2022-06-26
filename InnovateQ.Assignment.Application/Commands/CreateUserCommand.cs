using InnovateQ.Assignment.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Commands
{
    public class CreateUserCommand : IRequest<UserResponse> 
    {
        public string Name { get; set; }

        public string Designation { get; set; }

        public DateTime JoiningDate { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string? Street { get; set; }

        public string? PinCode { get; set; }

        public IFormFile? Image { get; set; }

        public string? ImagePath { get; set; }
    }
}
