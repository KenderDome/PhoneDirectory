namespace PhoneDirectory.Client.Auth
{
    public interface ILoginService
    {
        void Login(string token);
        void Logout();
    }
}
