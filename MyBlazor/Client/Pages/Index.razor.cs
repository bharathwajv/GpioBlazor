using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBlazor.Client.Pages
{
    public class IndexPage : ComponentBase
    {
        public static List<Item> ItemList = new List<Item>() { new Item { itemID = 5,itemName = "Coke", pinNumber = 11 ,leftAmount =5000},
         new Item { itemID = 16,itemName = "Pepsi", pinNumber = 12 ,leftAmount =4000},
         new Item { itemID = 45,itemName = "7up", pinNumber = 13 ,leftAmount =5000},
         new Item { itemID = 63,itemName = "Bear", pinNumber = 15 ,leftAmount =7000 } };


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
