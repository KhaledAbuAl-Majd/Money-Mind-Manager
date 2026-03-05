using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Models.Person;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.Person;

namespace MoneyMindManager.Application.Abstractions.Services
{
    public interface IPersonService
    {
        Task<IResult<PersonDTO>> Add(PersonDTO person, int currentUserID);
        Task<IResult<bool>> Update(PersonDTO person,int currentUserID);
        Task<IResult<PersonDTO>> Get(int personID, int currentUserID);
        Task<IResult<bool>> Delete(int personID, int currentUserID);
        Task<IResult<bool>> IsExist(int personID);
        Task<IResult<PagedResultDTO<PersonFullSummary>>> GetAll(PersonFilterDTO personFilterDTO, int currentUserID);
        Task<IResult<PagedResultDTO<PersonSelectSummary>>> GetAllForSelectOne(PersonSelectFilterDTO personFilterDTO, int currentUserID);
    }
}
