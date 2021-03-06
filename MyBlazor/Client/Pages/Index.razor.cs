using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyBlazor.Server.Controllers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlazor.Client.Pages
{
    public class IndexPage : ComponentBase
    {
        
        [Inject]
        public HttpClient HttpClient { get; set; }

        [Inject]
        public IJSRuntime JsRuntime { get; set; }

        public string BlinkyStatus;

        protected override async Task OnInitializedAsync()
        {
            var thisRef = DotNetObjectReference.Create(this);

            await JsRuntime.InvokeVoidAsync("blinkyFunctions.startBlinky", thisRef);
        }

        protected async Task StartBlinking()
        {
            await HttpClient.GetStringAsync("/api/Blinky/StartBlinking");
        }
        protected async Task StartBlinking(int pinNumber, int neededQuantity)
        {
            await HttpClient.GetStringAsync("/api/Blinky/StartBlinking/"+ pinNumber+"/"+ neededQuantity);
        }

        protected async Task StopBlinking()
        {
            await HttpClient.GetStringAsync("/api/Blinky/StopBlinking");
        }
        protected async Task SendItem(Item item)
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions{WriteIndented = true};
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(item, options);
            string jsonString = JsonSerializer.Serialize(item);
            await HttpClient.GetStringAsync("/api/Item/SendItem/"+item);
        }
        [JSInvokable]
        public async Task UpdateStatus()
        {
            var isBlinkingValue = await HttpClient.GetStringAsync("/api/Blinky/IsBlinking");

            if (string.IsNullOrEmpty(isBlinkingValue))
            {
                BlinkyStatus = "in unknown status";
            }
            else
            {
                bool.TryParse(isBlinkingValue, out var isBlinking);
                BlinkyStatus = isBlinking ? "blinking" : "not blinking";
            }

            StateHasChanged();
        }
    }
}
