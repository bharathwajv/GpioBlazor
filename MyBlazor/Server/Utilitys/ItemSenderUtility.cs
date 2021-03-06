using MyBlazor.Server.Controllers;
using MyBlazor.Server.Interfaces;
using System.Text.Json;

namespace MyBlazor.Server.Utilitys
{
    public class ItemSenderUtility : IItemSender
    {
        public void SendItemJson(Item item)
        {
            byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(item, options);
        }
    }
}
