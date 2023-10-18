using MediatR;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Sport.Commands
{
    public class DeleteSportCommand : IRequest<ResponseWrapper<bool>>
    {
        public int SportId { get; set; }
    }
    public class DeleteSportCommandHandler : IRequestHandler<DeleteSportCommand, ResponseWrapper<bool>>
    {
        private readonly ISportRepository _sportRepository;

        public DeleteSportCommandHandler(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public async Task<ResponseWrapper<bool>> Handle(DeleteSportCommand request, CancellationToken cancellationToken)
        {
            var sportInDb = await _sportRepository.GetSportByIdAsync(request.SportId);
            if (sportInDb is not null)
            {
                var isSuccessful = await _sportRepository.DeleteSportAsync(sportInDb);
                if (isSuccessful)
                {
                    return new ResponseWrapper<bool>().Success("Sport deleted successful.");
                }
                return new ResponseWrapper<bool>().Failed("Failed to delete sport.");
            }
            return new ResponseWrapper<bool>().Failed("Sport not found");
        }
    }
}
