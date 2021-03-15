using Microsoft.AspNetCore.Mvc;
using MyBlazor.Server.Controllers;
using MyBlazor.Server.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlazor.Server.Utilitys
{
    public class ItemSenderUtility : IItemSender
    {
        private string _jsonString;
        private string _statusString;

        // A read-write instance property:
        public string JsonString
        {
            get => _jsonString;
            set => _jsonString = value;
        }
        public string StatusString
        {
            get => _statusString;
            set => _statusString = value;
        }

        public async Task<string> SendItemJson([FromBody]ItemModel item)
        {
            //byte[] jsonUtf8Bytes;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Console.WriteLine("item Id, "+item.itemID);
            JsonString = System.Text.Json.JsonSerializer.Serialize(item);
            return "Item Added";
           // return 200;
            //return item.ToString();
            //jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(item, options);
        }
        public async Task<string> GetItemJson()
        {
            return JsonString; 
            // return Json(JsonString, JsonRequestBehavior.AllowGet);
            //return JsonString;
        }
        public async Task<string> DeleteItem([FromBody] ItemModel item)
        {
            try
            {
                return "Deleted";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            // return Json(JsonString, JsonRequestBehavior.AllowGet);
            //return JsonString;
        }
        public async Task<string> SendStationStatus([FromBody]string status)
        {
            try
            {
                StatusString = status;
                return StatusString + " Sent";
            }catch(Exception ex)
            {
                return ex.Message;
            }
            // return Json(JsonString, JsonRequestBehavior.AllowGet);
            //return JsonString;
        }
        public async Task<string> GetStationStatus()
        {
            return StatusString;
            // return Json(JsonString, JsonRequestBehavior.AllowGet);
            //return JsonString;
        }
    }
}
