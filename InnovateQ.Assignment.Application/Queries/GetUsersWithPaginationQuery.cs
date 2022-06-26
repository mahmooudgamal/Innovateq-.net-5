using InnovateQ.Assignment.Application.Common.Models;
using InnovateQ.Assignment.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Queries
{
    public class GetUsersWithPaginationQuery : IRequest<PaginatedList<UserResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortOrder { get; set; }

    }
}
