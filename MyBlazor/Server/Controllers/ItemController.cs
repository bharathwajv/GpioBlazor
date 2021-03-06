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
        [HttpGet("[action]/{item}")]
        public void SendItem(Item item)
        {
            _itemSenderUtility.SendItemJson(item);
        }
    }
}
