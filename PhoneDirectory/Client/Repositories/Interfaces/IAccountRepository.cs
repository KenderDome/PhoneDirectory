using PhoneDirectory.Shared.DTOs;
using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Client.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<UserToken> Login(UserInfo userInfo);
    }
}
