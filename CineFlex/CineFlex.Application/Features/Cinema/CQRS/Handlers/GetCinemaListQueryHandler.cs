using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Responses;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
{
    public class GetCinemaListQueryHandler : IRequestHandler<GetCinemaListQuery, BaseCommandResponse<List<CinemaDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCinemaListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<List<CinemaDto>>> Handle(GetCinemaListQuery request, CancellationToken cancellationToken)
        {

            var cinema = await _unitOfWork.CinemaRepository.GetAll();

            if (cinema == null || cinema.Count == 0)
            {
                // Return an error response if there are no cinema found
                return new BaseCommandResponse<List<CinemaDto>>
                {
                    Success = false,
                    Message = "No Cinema found."
                };
            }
            else
            {
                // Map the cinema list to a response DTO and return a success response
                return new BaseCommandResponse<List<CinemaDto>>
                {
                    Success = true,
                    Value = _mapper.Map<List<CinemaDto>>(cinema)
                };
            }
        }
    }
    }

