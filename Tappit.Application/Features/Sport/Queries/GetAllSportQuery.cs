using AutoMapper;
using MediatR;
using Tappit.Application.Models.Responses;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Sport.Queries
{
    public class GetAllSportQuery : IRequest<ResponseWrapper<List<SportResponse>>>
    {
    }
    public class GetAllSportQueryHandler : IRequestHandler<GetAllSportQuery, ResponseWrapper<List<SportResponse>>>
    {
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;

        public GetAllSportQueryHandler(ISportRepository sportRepository, IMapper mapper)
        {
            _sportRepository = sportRepository;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<List<SportResponse>>> Handle(GetAllSportQuery request, CancellationToken cancellationToken)
        {
            var sports = await _sportRepository.GetAllSportAsync();
            if (sports is not null && sports.Count > 0)
            {
                var sportResponse = _mapper.Map<List<SportResponse>>(sports);
                return new ResponseWrapper<List<SportResponse>>().SuccessWithData(sportResponse);
            }
            return new ResponseWrapper<List<SportResponse>>().Failed("No sport were not found");
        }
    }
}


