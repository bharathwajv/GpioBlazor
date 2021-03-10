using MyBlazor.Server.Controllers;
using System.Threading.Tasks;

namespace MyBlazor.Server.Interfaces
{
    public interface IItemSender
    {
        public Task SendItemJson(Item item);
        public Task<string> GetItemJson();
    }
}
