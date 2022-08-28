using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PhoneDirectory.Client.Rest;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PhoneDirectory.Client.Auth
{
    public class PhoneDirectoryAuthenticationStateProvider : AuthenticationStateProvider, ILoginService
    {
        private readonly string TOKENKEY = "TOKENKEY";
        private readonly IRestService restService;
        private readonly ISyncSessionStorageService sessionStorageService;

        private static AuthenticationState Anonymous =>
            new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        public PhoneDirectoryAuthenticationStateProvider(IRestService restService, ISyncSessionStorageService sessionStorageService)
        {
            this.restService = restService;
            this.sessionStorageService = sessionStorageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = sessionStorageService.GetItem<string>(TOKENKEY);

            if (string.IsNullOrEmpty(token))
                return Anonymous;

            return BuildAuthenticationState(token);
        }

        public AuthenticationState BuildAuthenticationState(string token)
        {
            restService.TOKENKEY = token;

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(token);

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(jwt.Claims, "jwt")));
        }

        public void Login(string token)
        {
            sessionStorageService.SetItemAsString(TOKENKEY, token);
            var authstate = BuildAuthenticationState(token);
            NotifyAuthenticationStateChanged(Task.FromResult(authstate));
        }

        public void Logout()
        {
            sessionStorageService.RemoveItem(TOKENKEY);
            restService.TOKENKEY = null;
            NotifyAuthenticationStateChanged(Task.FromResult(Anonymous));
        }
    }
}
