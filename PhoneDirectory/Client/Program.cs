using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PhoneDirectory.Client;
using PhoneDirectory.Client.Auth;
using PhoneDirectory.Client.Helpers;
using PhoneDirectory.Client.Helpers.Interfaces;
using PhoneDirectory.Client.Repositories;
using PhoneDirectory.Client.Repositories.Interfaces;
using PhoneDirectory.Client.Rest;
using System.Net.Http;

namespace PhoneDirectory.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");


            builder.Services.AddScoped<IRestService, RestService>();
            builder.Services.AddHttpClient<RestService>();

            builder.Services.AddAuthorizationCore();
            
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<PhoneDirectoryAuthenticationStateProvider>();

            builder.Services.AddScoped<AuthenticationStateProvider, PhoneDirectoryAuthenticationStateProvider>(provider => provider.GetRequiredService<PhoneDirectoryAuthenticationStateProvider>());
            builder.Services.AddScoped<ILoginService, PhoneDirectoryAuthenticationStateProvider>(provider => provider.GetRequiredService<PhoneDirectoryAuthenticationStateProvider>());

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();

            builder.Services.AddScoped<IDisplayMessage, DisplayMessage>();

            await builder.Build().RunAsync();
        }
    }
}