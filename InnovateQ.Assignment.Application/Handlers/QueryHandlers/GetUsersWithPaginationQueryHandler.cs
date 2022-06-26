using AutoMapper;
using AutoMapper.QueryableExtensions;
using InnovateQ.Assignment.Application.Common.Mapping;
using InnovateQ.Assignment.Application.Common.Models;
using InnovateQ.Assignment.Application.Mapper;
using InnovateQ.Assignment.Application.Queries;
using InnovateQ.Assignment.Application.Responses;
using InnovateQ.Assignment.Infrastructure.Data.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.Application.Handlers.QueryHandlers
{
    public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<UserResponse>>
    {
        /// <summary>   (Immutable) the context. </summary>
        private readonly InnovateqContext _context;

        public GetUsersWithPaginationQueryHandler(InnovateqContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<UserResponse>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            if (request.SortOrder == "Name")
            {
                return await _context.AppUsers
                            .OrderBy(x => x.Name)
                            .ProjectTo<UserResponse>(UserMapper.Mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);

            }
            else if (request.SortOrder == "JoiningDate")
            {
                return await _context.AppUsers
                            .OrderBy(x => x.JoiningDate)
                            .ProjectTo<UserResponse>(UserMapper.Mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);

            }
            else if (request.SortOrder == "Designation")
            {
                return await _context.AppUsers
                            .OrderBy(x => x.Designation)
                            .ProjectTo<UserResponse>(UserMapper.Mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);

            }
            else
            {
                return await _context.AppUsers
                            .OrderBy(x => x.JoiningDate)
                            .ProjectTo<UserResponse>(UserMapper.Mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageNumber, request.PageSize);
            }
        }

    }
}
