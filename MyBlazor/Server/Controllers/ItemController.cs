using Microsoft.AspNetCore.Mvc;
using MyBlazor.Server.Interfaces;

namespace MyBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemSender _itemSenderUtility;
        public ItemController(IItemSender ItemSenderUtility)
        {
            _itemSenderUtility = ItemSenderUtility;
        }
        [HttpPost]
        public async System.Threading.Tasks.Task SendItemAsync(Item item)
        {
            await _itemSenderUtility.SendItemJson(item);
        }
        [HttpGet]
        public async System.Threading.Tasks.Task GetItemAsync()
        {
            await _itemSenderUtility.GetItemJson();
        }
    }
}
