using AutoMapper;
using MediatR;
using Tappit.Application.Models.Requests;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Sport.Commands
{
    public class CreateSportCommand : IRequest<ResponseWrapper<bool>>
    {
        public NewSportRequest SportRequest { get; set; }
    }

    public class CreateSportCommandHandler : IRequestHandler<CreateSportCommand, ResponseWrapper<bool>>
    {
        private readonly ISportRepository _sportRepository;
        private readonly IMapper _mapper;

        public CreateSportCommandHandler(ISportRepository sportRepository, IMapper mapper)
        {
            _sportRepository = sportRepository;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<bool>> Handle(CreateSportCommand request, CancellationToken cancellationToken)
        {
            var sport = _mapper.Map<Domain.Sport>(request.SportRequest);
            var isSuccessful = await _sportRepository.CreateSportAsync(sport);
            if (isSuccessful)
            {
                return new ResponseWrapper<bool>().Success("Sport created successful.");
            }
            return new ResponseWrapper<bool>().Failed("Failed to create sport.");
        }
    }
}

