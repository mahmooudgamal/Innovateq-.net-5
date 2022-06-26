using InnovateQ.Assignment.Application.Commands;
using InnovateQ.Assignment.Application.Common.Models;
using InnovateQ.Assignment.Application.Queries;
using InnovateQ.Assignment.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InnovateQ.Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator,
            IWebHostEnvironment webHostEnvironment,
            ILogger<UserController> logger)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<InnovateQ.Assignment.Core.Entities.User>> Get()
        {
            return await _mediator.Send(new GetAllUserQuery());
        }

        [HttpGet]
        [Route("GetUsersWithPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedList<UserResponse>>> GetUsersWithPagination([FromQuery] GetUsersWithPaginationQuery query)
        {
            _logger.LogInformation("Call GetusersWithPagination with Page {id} - {Size}", query.PageNumber, query.PageSize);

            var result = await _mediator.Send(query);
            return Ok(result);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> CreateUser([FromForm] CreateUserCommand command)
        {
            if (command.Image != null && command.Image.Length > 0)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string contentRootPath = _webHostEnvironment.ContentRootPath;
                var path = Path.Combine("UserImage", Guid.NewGuid().ToString() + Path.GetExtension(command.Image.FileName));
                //Save the file to disk
                using (var stream = System.IO.File.Create(Path.Combine(webRootPath, path)))
                {
                    await command.Image.CopyToAsync(stream);
                }
                command.ImagePath = path;
            }
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> UpdateUser(int id, [FromForm] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
