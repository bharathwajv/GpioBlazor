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
        [HttpPost("item")]
        public async System.Threading.Tasks.Task<IActionResult> SendItemAsync(Item item)
        {
            return Ok(await _itemSenderUtility.SendItemJson(item));
        }
        [HttpPost("status")]
        public async System.Threading.Tasks.Task<IActionResult> SendStationStatus(string status)
        {
            return Ok(await _itemSenderUtility.SendStationStatus(status));
        }
        [HttpGet("GetItem")]
        public async System.Threading.Tasks.Task<IActionResult> GetItemAsync()
        {
            return Ok(await _itemSenderUtility.GetItemJson());
        }
        [HttpGet("GetStation")]
        public async System.Threading.Tasks.Task<IActionResult> GetStationStatus()
        {
            return Ok(await _itemSenderUtility.GetStationStatus());
        }
        
    }
}
