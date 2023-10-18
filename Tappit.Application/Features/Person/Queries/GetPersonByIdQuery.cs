using AutoMapper;
using MediatR;
using Tappit.Application.Models.Responses;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Person.Queries
{
    public class GetPersonByIdQuery : IRequest<ResponseWrapper<PersonResponse>>
    {
        public int Id { get; set; }
    }
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, ResponseWrapper<PersonResponse>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<PersonResponse>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var personInDb = await _personRepository.GetPersonByIdAsync(request.Id);
            if (personInDb is not null)
            {
                var personResponse = _mapper.Map<PersonResponse>(personInDb);
                return new ResponseWrapper<PersonResponse>().SuccessWithData(personResponse);
            }
            return new ResponseWrapper<PersonResponse>().Failed("Person not found");
        }
    }
}
