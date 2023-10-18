using AutoMapper;
using MediatR;
using Tappit.Application.Models.Responses;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Sport.Queries
{
    public class GetSportByIdQuery : IRequest<ResponseWrapper<SportResponse>>
    {
        public int Id { get; set; }
    }
    public class GetSportByIdQueryHandler : IRequestHandler<GetSportByIdQuery, ResponseWrapper<SportResponse>>
    {
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;

        public GetSportByIdQueryHandler(ISportRepository sportRepository, IMapper mapper)
        {
            _sportRepository = sportRepository;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<SportResponse>> Handle(GetSportByIdQuery request, CancellationToken cancellationToken)
        {
            var sportInDb = await _sportRepository.GetSportByIdAsync(request.Id);
            if (sportInDb is not null)
            {
                var sportResponse = _mapper.Map<SportResponse>(sportInDb);
                return new ResponseWrapper<SportResponse>().SuccessWithData(sportResponse);
            }
            return new ResponseWrapper<SportResponse>().Failed("Sport not found");
        }
    }
}


