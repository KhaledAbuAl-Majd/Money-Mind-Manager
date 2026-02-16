using System.Threading.Tasks;
using MoneyMindManager.Core.Abstractions;
using MoneyMindManager.Core.Paged_Result_DTOs;
using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Domain.NewFolder1;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface IPersonRepository
    {
        /// <returns>New PersonID if Success, if failed return null</returns>
        Task<IResult<int?>> Add(Person person);

        /// <returns>Updating Result</returns>
        Task<IResult<bool>> Update(Person person, int currentUserID);

        Task<IResult<bool>> Delete(int personID, int currentUserID);

        /// <returns>Object of Person, if person is not found it will return null</returns>
        Task<IResult<Person>> Get(int personID, int currentUserID);

        // <returns>true if person exist, false if person not exist</returns>
        Task<IResult<bool>> IsExist(int personID);

        /// <summary>
        /// Get All People For Account Using Paging , if variable null will not filter by it.
        /// </summary>
        /// <returns>object of PagedResultDTO<Person> : if error happend, return null</returns>
        Task<IResult<PagedResultDTO<Person>>> GetAll(PersonSearchCriteria personSearchCriteria, int currentUserID);

        Task<IResult<PagedResultDTO<Person>>> GetAllForSelectOne(PersonSelectSearchCriteria personSearchCriteria, int currentUserID);
    }
}
