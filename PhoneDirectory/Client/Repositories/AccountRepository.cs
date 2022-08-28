using PhoneDirectory.Client.Repositories.Interfaces;
using PhoneDirectory.Client.Rest;
using PhoneDirectory.Shared.DTOs;
using PhoneDirectory.Shared.Entities;
using System.Text;
using System.Text.Json;

namespace PhoneDirectory.Client.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        
        private readonly IRestService restClient;

        public AccountRepository(IRestService restClient)
        {
            
            this.restClient = restClient;
        }
        public async Task<UserToken> Login(UserInfo userInfo)
        {

            UserToken token = await restClient.PostAsync<UserToken>("authorization/login", userInfo);

            return token;

        }
    }
}
