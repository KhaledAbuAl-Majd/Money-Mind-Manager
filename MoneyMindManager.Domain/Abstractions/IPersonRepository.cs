using System.Threading.Tasks;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs;
using MoneyMindManager.Shared.DTOs.Person;

namespace MoneyMindManager.Domain.Abstractions
{
    public interface IPersonRepository
    {
        /// <returns>New PersonID if Success, if failed return null</returns>
        Task<int?> Add(Person person);

        /// <returns>Updating Result</returns>
        Task<bool> Update(Person person, int currentUserID);

        Task<bool> Delete(int personID, int currentUserID);

        /// <returns>Object of Person, if person is not found it will return null</returns>
        Task<Person> Get(int personID, int currentUserID);

        // <returns>true if person exist, false if person not exist</returns>
        Task<bool> IsExist(int personID);

        /// <summary>
        /// Get All People For Account Using Paging , if variable null will not filter by it.
        /// </summary>
        /// <returns>object of PagedResultDTO<Person> : if error happend, return null</returns>
        Task<PagedResultDTO<Person>> GetAll(PersonFilterDTO personFilterDTO,byte rowsPerPage, int currentUserID);

        Task<PagedResultDTO<Person>> GetAllForSelectOne(PersonFilterDTO personFilterDTO, byte rowsPerPage, int currentUserID);
    }
}
