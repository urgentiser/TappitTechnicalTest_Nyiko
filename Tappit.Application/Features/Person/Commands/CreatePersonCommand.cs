using AutoMapper;
using MediatR;
using Tappit.Application.Models.Requests;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Person.Commands
{
    public class CreatePersonCommand : IRequest<ResponseWrapper<bool>>
    {
        public NewPersonRequest PersonRequest { get; set; }
    }
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ResponseWrapper<bool>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<bool>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Domain.Person person = _mapper.Map<Domain.Person>(request.PersonRequest);
            var isSuccessful = await _personRepository.CreatePersonAsync(person);
            if (isSuccessful)
            {
                return new ResponseWrapper<bool>().Success("Person created successful.");
            }
            return new ResponseWrapper<bool>().Failed("Failed to create Person.");
        }
    }
}


