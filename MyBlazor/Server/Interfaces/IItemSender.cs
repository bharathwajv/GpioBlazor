using Microsoft.AspNetCore.Mvc;
using MyBlazor.Server.Controllers;
using System.Threading.Tasks;

namespace MyBlazor.Server.Interfaces
{
    public interface IItemSender
    {
        public Task<string> SendItemJson(Item item);
        public Task<string> GetItemJson();
        public Task<string> GetStationStatus();
        public Task<string> SendStationStatus(string status);
    }
}
