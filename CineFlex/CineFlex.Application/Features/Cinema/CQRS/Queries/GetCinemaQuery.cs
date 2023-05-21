using BlogApp.Application.Responses;
using CineFlex.Application.Features.Cinema.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Queries
{
    public class GetCinemaQuery: IRequest<BaseCommandResponse<CinemaDto>>
    {
        public int Id { get; set; }
    }
}
