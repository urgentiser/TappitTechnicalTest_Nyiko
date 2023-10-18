using MediatR;
using Tappit.Application.Models.Requests;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Sport.Commands
{
    public class UpdateSportCommand : IRequest<ResponseWrapper<bool>>
    {
        public UpdateSportRequest SportRequest { get; set; }
    }
    public class UpdatePolicyCommandHandler : IRequestHandler<UpdateSportCommand, ResponseWrapper<bool>>
    {
        private readonly ISportRepository _sportRepository;

        public UpdatePolicyCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public async Task<ResponseWrapper<bool>> Handle(UpdateSportCommand request, CancellationToken cancellationToken)
        {
            var sportInDb = await _sportRepository.GetSportByIdAsync(request.SportRequest.SportId);
            if (sportInDb is not null)
            {
                var updatedSport = sportInDb
                    .UpdateProperties(request.SportRequest.Name);

                var isSuccessful = await _sportRepository.UpdateSportAsync(updatedSport);
                if (isSuccessful)
                {
                    return new ResponseWrapper<bool>().Success("Sport updated successful.");
                }
                return new ResponseWrapper<bool>().Failed("Failed to update Sport.");
            }
            return new ResponseWrapper<bool>().Failed("Sport not found");
        }
    }
}
