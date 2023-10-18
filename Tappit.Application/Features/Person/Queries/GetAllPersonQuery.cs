using AutoMapper;
using MediatR;
using Tappit.Application.Models.Responses;
using Tappit.Application.Models.Wrappers;
using Tappit.Application.Repositories;

namespace Tappit.Application.Features.Person.Queries
{
    public class GetAllPersonQuery : IRequest<ResponseWrapper<List<PersonResponse>>>
    {

    }
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, ResponseWrapper<List<PersonResponse>>>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public GetAllPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResponseWrapper<List<PersonResponse>>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var people = await _personRepository.GetAllPersonAsync();
            if (people is not null && people.Count > 0)
            {
                var personResponse = _mapper.Map<List<PersonResponse>>(people);
                return new ResponseWrapper<List<PersonResponse>>().SuccessWithData(personResponse);
            }
            return new ResponseWrapper<List<PersonResponse>>().Failed("Person not found");
        }
    }
}
