using InnovateQ.Assignment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Commands
{
    public class UpdateUserCommand : IRequest<UserResponse>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Designation { get; set; }

        public DateTime JoiningDate { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string? Street { get; set; }

        public string? PinCode { get; set; }


    }
}
