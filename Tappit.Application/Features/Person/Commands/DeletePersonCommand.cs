using MediatR;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Person.Commands
{
    public class DeletePersonCommand : IRequest<ResponseWrapper<bool>>
    {
        public int Id { get; set; }
    }
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, ResponseWrapper<bool>>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<ResponseWrapper<bool>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var personInDb = await _personRepository.GetPersonByIdAsync(request.Id);
            if (personInDb is not null)
            {
                var isSuccessful = await _personRepository.DeletePersonAsync(personInDb);
                if (isSuccessful)
                {
                    return new ResponseWrapper<bool>().Success("Person deleted successful.");
                }
                return new ResponseWrapper<bool>().Failed("Failed to delete Person.");
            }
            return new ResponseWrapper<bool>().Failed("Person not found");
        }
    }
}
