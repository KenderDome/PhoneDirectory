namespace PhoneDirectory.Client.Helpers.Interfaces
{
    public interface IDisplayMessage
    {
        ValueTask<bool> Confirm(string title, string message);
        ValueTask ShowErrorMessage(string title, string message);
        ValueTask ShowMessage(string title, string message, string messageType);
        ValueTask ShowSuccessMessage(string title, string message);

    }
}
