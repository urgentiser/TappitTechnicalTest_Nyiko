using MediatR;
using Tappit.Application.Models.Requests;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Person.Commands
{
    public class UpdatePersonCommand : IRequest<ResponseWrapper<bool>>
    {
        public UpdatePersonRequest PersonRequest { get; set; }
    }
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, ResponseWrapper<bool>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IFavouriteSportRepository _favouriteSportRepository;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, IFavouriteSportRepository favouriteSportRepository)
        {
            _personRepository = personRepository;
            _favouriteSportRepository = favouriteSportRepository;
        }

        public async Task<ResponseWrapper<bool>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var personInDb = await _personRepository.GetPersonByIdAsync(request.PersonRequest.PersonId);
            if (personInDb is not null)
            {
                var updatedPerson = personInDb.UpdateProperties(request.PersonRequest.FirstName, request.PersonRequest.LastName);
                var isSuccessful = await _personRepository.UpdatePersonAsync(updatedPerson);

                // Remove previous favourites
                await _favouriteSportRepository.ClearPersonPreviousFavourites(request.PersonRequest.PersonId);
                
                // Update favourite sports
                var favourites = request.PersonRequest.FavouriteSports
                    .Where(fs => fs.IsFavourite).ToList();
                
                foreach (var favourite in favourites)
                {
                    var isFavAdded = await _favouriteSportRepository.AssignFavaouriteSport(new Domain.FavouriteSport
                    {
                        PersonId = favourite.PersonId,
                        SportId = favourite.SportId,
                    });
                }

                if (isSuccessful)
                {
                    return new ResponseWrapper<bool>().Success("Person updated successful.");
                }
                return new ResponseWrapper<bool>().Failed("Failed to update Person.");
            }
            return new ResponseWrapper<bool>().Failed("Person not found");
        }
    }
}
