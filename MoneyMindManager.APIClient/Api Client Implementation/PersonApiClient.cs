using System.Threading.Tasks;
using MoneyMindManager.Application.Abstractions.Services;
using MoneyMindManager.Client.Abstractions.ApiClient;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.Person;

namespace MoneyMindManager.APIClient.Api_Client_Implementation
{
    public class PersonApiClient : IPersonApiClient
    {
        private readonly IPersonService _personService;

        public PersonApiClient(IPersonService personService)
        {
            this._personService = personService;
        }

        public async Task<IResult<PersonDTO>> Add(PersonDTO person, int currentUserID)
        {
            return await _personService.Add(person, currentUserID);
        }

        public async Task<IResult<bool>> Update(PersonDTO person, int currentUserID)
        {
            return await _personService.Update(person, currentUserID);
        }

        public async Task<IResult<PersonDTO>> Get(int personID, int currentUserID)
        {
            return await _personService.Get(personID, currentUserID);
        }

        public async Task<IResult<bool>> Delete(int personID, int currentUserID)
        {
            return await _personService.Delete(personID, currentUserID);
        }

        public async Task<IResult<bool>> IsExist(int personID)
        {
            return await _personService.IsExist(personID);
        }

        public async Task<IResult<PagedResultDTO<PersonDTO>>> GetAll(PersonFilterDTO personFilterDTO, int currentUserID)
        {
            return await _personService.GetAll(personFilterDTO, currentUserID);
        }

        public async Task<IResult<PagedResultDTO<PersonDTO>>> GetAllForSelectOne(PersonSelectFilterDTO personFilterDTO, int currentUserID)
        {
            return await _personService.GetAllForSelectOne(personFilterDTO, currentUserID);
        }
    }
}
