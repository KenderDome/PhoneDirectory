using Microsoft.JSInterop;
using PhoneDirectory.Client.Helpers.Interfaces;
using System.Text.Json;

namespace PhoneDirectory.Client.Helpers
{
    public class DisplayMessage : IDisplayMessage
    {
        private readonly IJSRuntime jSRuntime;

        public DisplayMessage(IJSRuntime jSRuntime)
        {
            this.jSRuntime = jSRuntime;
        }

        public async ValueTask ShowMessage(string title, string message, string messageType)
        {
            await jSRuntime.InvokeVoidAsync("Swal.fire", title, message, messageType);
        }

        public async ValueTask ShowSuccessMessage(string title, string message)
        {
            await ShowMessage(title, message, "success");
        }

        public async ValueTask ShowErrorMessage(string title, string message)
        {
            await ShowMessage(title, message, "error");
        }

        public async ValueTask<bool> Confirm(string title, string message)
        {
            var confirmObj = new
            {
                title = title,
                text = message,
                icon = "warning",
                showCancelButton = true
            };

            var returnObj = await jSRuntime.InvokeAsync<object>("Swal.fire", confirmObj).ConfigureAwait(false);

            if (returnObj != null)
            {
                SweetAlertReturnObject? response = JsonSerializer.Deserialize<SweetAlertReturnObject>
                    (returnObj.ToString() ?? "", new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (response != null)
                    return response.Value;
            }

            return false;
        }
    }
}
