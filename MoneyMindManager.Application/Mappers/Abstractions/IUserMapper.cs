using MoneyMindManager.Domain.Criteria;
using MoneyMindManager.Domain.Entities;
using MoneyMindManager.Shared.DTOs.User;

namespace MoneyMindManager.Application.Abstractions.Mappers
{
    public interface IUserMapper : IMapper<User, UserDTO>
    {
        UserSearchCriteria ToSearchCriteria(UserFilterDTO userFilterDTO);
    }
}
