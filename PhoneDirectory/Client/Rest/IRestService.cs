namespace PhoneDirectory.Client.Rest
{
    public interface IRestService
    {
        public string? TOKENKEY { get; set; }

        Task DeleteAsync(string url);
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, object data);
        Task<T> PutAsync<T>(string url, object data);
    }
}
