using Microsoft.AspNetCore.Mvc;
using MyBlazor.Server.Controllers;
using MyBlazor.Server.Interfaces;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlazor.Server.Utilitys
{
    public class ItemSenderUtility : IItemSender
    {
        private string _jsonString;

        // A read-write instance property:
        public string JsonString
        {
            get => _jsonString;
            set => _jsonString = value;
        }

        public async Task SendItemJson([FromBody]Item item)
        {
            //byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Console.WriteLine("pin number, "+item.pinNumber);
            Console.WriteLine("item Id, "+item.itemID);
            JsonString = System.Text.Json.JsonSerializer.Serialize(item);
           // return 200;
            //return item.ToString();
            //jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(item, options);
        }
        public async Task<string> GetItemJson()
        {
            return JsonConvert.SerializeObject(JsonString);
            // return Json(JsonString, JsonRequestBehavior.AllowGet);
            //return JsonString;
        }
    }
}
