using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.Person;

namespace MoneyMindManager.Client.Abstractions.ApiClient
{
    public interface IPersonApiClient
    {
        Task<IResult<PersonDTO>> Add(PersonDTO person, int currentUserID);
        Task<IResult<bool>> Update(PersonDTO person, int currentUserID);
        Task<IResult<PersonDTO>> Get(int personID, int currentUserID);
        Task<IResult<bool>> Delete(int personID, int currentUserID);
        Task<IResult<bool>> IsExist(int personID);
        Task<IResult<PagedResultDTO<PersonDTO>>> GetAll(PersonFilterDTO personFilterDTO, int currentUserID);
        Task<IResult<PagedResultDTO<PersonDTO>>> GetAllForSelectOne(PersonSelectFilterDTO personFilterDTO, int currentUserID);
    }
}
